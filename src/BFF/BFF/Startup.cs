using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BFF.Constants;
using BFF.DAL;
using BFF.Repositories;
using BFF.Repositories.Abstractions;
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

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicies.AngularClient,
                    buillder => { buillder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod(); });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}