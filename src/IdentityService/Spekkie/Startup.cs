// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Spekkie.Data;
using Spekkie.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Minor.Miffy.MicroServices.Commands;
using Spekkie.Constants;

namespace Spekkie
{
    public class Startup
    {
        public static bool RegisterEnabled { get; set; }
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;

            var registerEnabled = System.Environment.GetEnvironmentVariable(EnvNames.RegisterEnabled);
            RegisterEnabled = registerEnabled == "true";
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var loggerFactory = LoggerFactory.Create(configure =>
            {
                configure.AddConsole().SetMinimumLevel(LogLevel.Debug);
            });

            var config = new Config(loggerFactory);

            services.AddSingleton(loggerFactory);
            services.AddSingleton(Program.BusContext);
            services.AddTransient<ICommandPublisher, CommandPublisher>();
            
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // options.UseMySql(System.Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
                options.UseSqlServer(System.Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
                options.UseLoggerFactory(loggerFactory);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.EnsureDefaultUsersAccounts(SeedData.DefaultUserAccounts);

            var builder = services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    // options.PublicOrigin = "https://identity.dirk-jan.eu";
                    options.PublicOrigin = System.Environment.GetEnvironmentVariable(EnvNames.PublicOrigin) 
                                           ?? throw new Exception($"Environment variable {EnvNames.PublicOrigin} was not set");
                })
                .AddInMemoryIdentityResources(config.Ids)
                .AddInMemoryApiResources(config.Apis)
                .AddInMemoryClients(config.Clients)
                .AddAspNetIdentity<ApplicationUser>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication();
                // .AddGoogle(options =>
                // {
                //     // register your IdentityServer with Google at https://console.developers.google.com
                //     // enable the Google+ API
                //     // set the redirect URI to http://localhost:5000/signin-google
                //     options.ClientId = "copy client ID from Google here";
                //     options.ClientSecret = "copy client secret from Google here";
                // });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthPolicies.SpekkieAccountViewAllPolicy,
                    policy => policy.RequireClaim(AuthClaims.SpekkieAccountViewAll, AuthClaims.True));
                
                options.AddPolicy(AuthPolicies.SpekkieAccountRemovePolicy,
                    policy => policy.RequireClaim(AuthClaims.SpekkieAccountRemove, AuthClaims.True));

                options.AddPolicy(AuthPolicies.SpekkieAccountClaimViewAllPolicy,
                    policy => policy.RequireClaim(AuthClaims.SpekkieAccountClaimViewAll, AuthClaims.True));

                options.AddPolicy(AuthPolicies.SpekkieAccountClaimAddPolicy,
                    policy => policy.RequireClaim(AuthClaims.SpekkieAccountClaimAdd, AuthClaims.True));

                options.AddPolicy(AuthPolicies.SpekkieAccountClaimRemovePolicy,
                    policy => policy.RequireClaim(AuthClaims.SpekkieAccountClaimRemove, AuthClaims.True));

                options.AddPolicy(AuthPolicies.SpekkieSettingsViewAllPolicy,
                    policy => policy.RequireClaim(AuthClaims.SpekkieSettingsViewAll, AuthClaims.True));
                
                options.AddPolicy(AuthPolicies.SpekkieSettingsCanEnableDisableRegisterPolicy,
                    policy => policy.RequireClaim(AuthClaims.SpekkieSettingsCanEnableDisableRegister, AuthClaims.True));
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}