using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BFF.Constants;
using BFF.DAL;
using BFF.Repositories;
using BFF.Repositories.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BFF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOefeningRepository, OefeningRepository>();
            services.AddScoped<IPrestatieRepository, PrestatieRepository>();
            services.AddDbContext<BFFContext>(e =>
            {
                e.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
            });

            // You need to comment this when adding a migration
            using var serviceScope = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<BFFContext>();
            context.Database.Migrate();
            // You need to comment this when adding a migration
            
            services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.Authority = Environment.GetEnvironmentVariable(EnvNames.AuthenticationServerAddress);
                options.RequireHttpsMetadata = false;
                options.Audience = AuthConfig.Audience;
                
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        if (context.SecurityToken is JwtSecurityToken accessToken)
                        {
                            var appIdentity = new ClaimsIdentity(accessToken.Claims, JwtBearerDefaults.AuthenticationScheme);
                            context.Principal.AddIdentity(appIdentity);
                        }
            
                        return Task.CompletedTask;
                    }
                };
            });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthPolicies.KanOefeningenZienPolicy, policy =>
                {
                    policy.RequireClaim(AuthClaims.FitFlexOefeningRead, AuthClaims.True);
                    policy.RequireClaim(AuthClaims.FitFlexOefeningPrestatieRead, AuthClaims.True);
                });
                options.AddPolicy(AuthPolicies.KanOefeningenToevoegenPolicy, policy => policy.RequireClaim(AuthClaims.FitFlexOefeningAdd, AuthClaims.True));
                options.AddPolicy(AuthPolicies.KanPrestatiesToevoegenPolicy, policy => policy.RequireClaim(AuthClaims.FitFlexOefeningPrestatieAdd, AuthClaims.True));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicies.AngularClient,
                    buillder => { 
                        buillder
                            // .WithOrigins("https://fit.djja.nl")
                            // .WithOrigins("https://fit.dirk-jan.eu")
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials(); 
                    });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsPolicies.AngularClient);
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}