using System;
using KlantService.Constants;
using KlantService.DAL;
using KlantService.Repositories;
using KlantService.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minor.Miffy;
using Minor.Miffy.MicroServices;
using Minor.Miffy.RabbitMQBus;
using RabbitMQ.Client;

namespace KlantService
{
    class Program
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
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<KlantContext>(e =>
                    {
                        e.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
                        // e.UseLoggerFactory(loggerFactory);
                    });
                    services.AddSingleton<IKlantRepository, KlantRepository>();
                    
                    using var serviceScope = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>()
                        .CreateScope();

                    var dbContext = serviceScope.ServiceProvider.GetService<KlantContext>();
                    dbContext.Database.Migrate();
                });
        }
        
    }
}