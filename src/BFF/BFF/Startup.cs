using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using BFF.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                    policy.RequireClaim(AuthClaims.FitOefeningRead, AuthClaims.True);
                    policy.RequireClaim(AuthClaims.FitOefeningPrestatieRead, AuthClaims.True);
                });
                options.AddPolicy(AuthPolicies.KanOefeningenToevoegenPolicy, policy => policy.RequireClaim(AuthClaims.FitOefeningAdd, AuthClaims.True));
                options.AddPolicy(AuthPolicies.KanOefeningenAanpassenPolicy, policy => policy.RequireClaim(AuthClaims.FitOefeningEdit, AuthClaims.True));
                options.AddPolicy(AuthPolicies.KanPrestatiesToevoegenPolicy, policy => policy.RequireClaim(AuthClaims.FitOefeningPrestatieAdd, AuthClaims.True));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicies.AngularClient,
                    builder => { 
                        builder
                            .WithOrigins("https://fit.dirk-jan.eu")
                            .WithOrigins("http://localhost:4200")
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