using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BFF.Constants;
using BFF.DAL;
using BFF.Repositories;
using BFF.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Minor.Miffy;
using Minor.Miffy.MicroServices.Host;
using Minor.Miffy.RabbitMQBus;
using RabbitMQ.Client;

namespace BFF
{
    public class Program
    {
        private const string QueueName = "Fit.FrontendService.Queue";
        
        public static IBusContext<IConnection> BusContext { get; set; }
        
        public static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(configure =>
            {
                configure.AddConsole().SetMinimumLevel(LogLevel.Debug);
            });

            var serviceCollection = RegisterMiffyDependencies();

            MiffyLoggerFactory.LoggerFactory = loggerFactory;
            RabbitMqLoggerFactory.LoggerFactory = loggerFactory;

            using var context = new RabbitMqContextBuilder()
                .ReadFromEnvironmentVariables()
                .CreateContext();
            
            BusContext = context;

            using var host = new MicroserviceHostBuilder()
                .SetLoggerFactory(loggerFactory)
                .WithBusContext(context)
                .WithQueueName(QueueName)
                .UseConventions()
                .RegisterDependencies(serviceCollection)
                .CreateHost();
            
            // You need to comment this when adding a migration
            using var serviceScope = serviceCollection.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var dbContext = serviceScope.ServiceProvider.GetService<BFFContext>();
            dbContext.Database.Migrate();
            // You need to comment this when adding a migration

            host.Start();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static IServiceCollection RegisterMiffyDependencies()    // This way the miffy host cannot access different repositories beside the ones it's allowed to use
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IKlantRepository, KlantRepository>();
            serviceCollection.AddTransient<IOefeningRepository, OefeningRepository>();
            serviceCollection.AddTransient<IPrestatieRepository, PrestatieRepository>();
            serviceCollection.AddDbContext<BFFContext>(e =>
            {
                e.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
            });

            return serviceCollection;
        }
    }
}