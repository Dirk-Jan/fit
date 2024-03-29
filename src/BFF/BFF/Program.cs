using System;
using BFF.Constants;
using BFF.DAL;
using BFF.Repositories;
using BFF.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minor.Miffy;
using Minor.Miffy.MicroServices;
using Minor.Miffy.RabbitMQBus;
using RabbitMQ.Client;

namespace BFF
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var connectionFactory = new ConnectionFactory();
            var contextBuilder = new RabbitMQContextBuilder(connectionFactory)
                .ReadFromEnvironmentVariables();
            IBusContext<IConnection> busContext = contextBuilder.CreateContext();

            return Host.CreateDefaultBuilder(args)
                .ConfigureMessageBusWrapperHostDefaults(builder => { }, busContext)
                // .ConfigureMessageBusWrapperClientDefaults(builder => { }, busContext)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    services.AddDbContext<BFFContext>(e =>
                    {
                        e.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
                    });
                    services.AddTransient<IKlantRepository, KlantRepository>();
                    services.AddTransient<IOefeningRepository, OefeningRepository>();
                    services.AddTransient<IPrestatieRepository, PrestatieRepository>();
                    services.AddTransient<IWorkoutRepository, WorkoutRepository>();
                    
                    
                    // You need to comment this when adding a migration
                    using var serviceScope = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>()
                        .CreateScope();
                    using var dbContext = serviceScope.ServiceProvider.GetService<BFFContext>();
                    dbContext.Database.Migrate();
                    // You need to comment this when adding a migration
                });
        }
        
    }
}