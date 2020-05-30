﻿using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Minor.Miffy;
using Minor.Miffy.MicroServices.Events;
using Minor.Miffy.MicroServices.Host;
using Minor.Miffy.RabbitMQBus;
using PrestatieService.Constants;
using PrestatieService.DAL;
using PrestatieService.Repositories;
using PrestatieService.Repositories.Abstractions;

namespace PrestatieService
{
    class Program
    {
        private const string QueueName = "Fit.PrestatieService.Queue";
        
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(configure =>
            {
                configure.AddConsole().SetMinimumLevel(LogLevel.Debug);
            });

            MiffyLoggerFactory.LoggerFactory = loggerFactory;
            RabbitMqLoggerFactory.LoggerFactory = loggerFactory;

            using var context = new RabbitMqContextBuilder()
                .ReadFromEnvironmentVariables()
                .CreateContext();

            using var host = new MicroserviceHostBuilder()
                .SetLoggerFactory(loggerFactory)
                .RegisterDependencies(services =>
                {
                    services.AddDbContext<PrestatieContext>(e =>
                    {
                        e.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
                        e.UseLoggerFactory(loggerFactory);
                    });

                    services.AddSingleton(context);
                    services.AddSingleton<IPrestatieRepository, PrestatieRepository>();
                    services.AddTransient<IEventPublisher, EventPublisher>();

                    using var serviceScope = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>()
                        .CreateScope();

                    var dbContext = serviceScope.ServiceProvider.GetService<PrestatieContext>();
                    dbContext.Database.EnsureCreated();
                })
                .WithBusContext(context)
                .WithQueueName(QueueName)
                .UseConventions()
                .CreateHost();

            host.Start();

            // Keep the application running
            new AutoResetEvent(false).WaitOne();
        }
    }
}