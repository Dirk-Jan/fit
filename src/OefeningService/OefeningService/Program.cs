using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minor.Miffy;
using Minor.Miffy.MicroServices;
using Minor.Miffy.RabbitMQBus;
using OefeningService.Constants;
using OefeningService.DAL;
using OefeningService.Repositories;
using OefeningService.Repositories.Abstractions;
using RabbitMQ.Client;

namespace OefeningService
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
                    services.AddDbContext<OefeningContext>(e =>
                    {
                        e.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
                        // e.UseLoggerFactory(loggerFactory);
                    });
                    services.AddSingleton<IOefeningRepository, OefeningRepository>();
                    
                    using var serviceScope = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>()
                        .CreateScope();

                    var dbContext = serviceScope.ServiceProvider.GetService<OefeningContext>();
                    dbContext.Database.Migrate();
                });
        }
        
    }
}