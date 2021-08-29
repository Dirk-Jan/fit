using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Minor.Miffy;
using Minor.Miffy.MicroServices;
using Minor.Miffy.RabbitMQBus;
using RabbitMQ.Client;
using Serilog;

namespace Spekkie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            Log.Information("Starting host...");
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var connectionFactory = new ConnectionFactory();
            var contextBuilder = new RabbitMQContextBuilder(connectionFactory)
                .ReadFromEnvironmentVariables();
            IBusContext<IConnection> busContext = contextBuilder.CreateContext();
            
            return Host.CreateDefaultBuilder(args)
                .ConfigureMessageBusWrapperClientDefaults(builder => { }, busContext)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog();
                });
        }
    }
}