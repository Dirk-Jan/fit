using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImportExportTool.Logic;
using ImportExportTool.Models;
using Microsoft.Extensions.Logging;
using Minor.Miffy;
using Minor.Miffy.MicroServices.Commands;
using Minor.Miffy.MicroServices.Host;
using Minor.Miffy.RabbitMQBus;

namespace ImportExportTool
{
    class Program
    {
        private const string QueueName = "Fit.ImportExportTool.Queue";
        
        static void Main(string[] args)
        {
            Console.Write("Enter RabbitMQ connection string: ");
            var connectionString = Console.ReadLine();
            Console.WriteLine($"Using RabbitMQ connection string: '{connectionString}'");
            Environment.SetEnvironmentVariable("BROKER_CONNECTION_STRING", connectionString);
            
            Console.WriteLine();
            
            Console.Write("Enter MSSQL connection string: ");
            connectionString = Console.ReadLine();
            Console.WriteLine($"Using MSSQL connection string: '{connectionString}'");
            Environment.SetEnvironmentVariable("DB_CONNECTION_STRING", connectionString);

            Console.WriteLine();

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
                .WithBusContext(context)
                .WithQueueName(QueueName)
                .UseConventions()
                .CreateHost();

            host.Start();
            
            
            ICommandPublisher commandPublisher = new CommandPublisher(context);
            var klantId = Guid.Empty;

            Export();
            // ImportDataIntoSystemFromFile(commandPublisher, klantId, @"C:\Users\Dirk-Jan\Dropbox\S6\Fitness Prestaties.txt");
        }


        static void ImportDataIntoSystemFromFile(ICommandPublisher commandPublisher, Guid klantId, string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var exporter = new TextDataExporter();
            var oefeningen = exporter.ReadAllOefeningenWithPrestatiesFromLines(lines);
            
            var importer = new DataImporter(commandPublisher);
            importer.ImportOefeningenIntoSystem(oefeningen.ToList(), klantId);
        }
        
        
        
        // POCs below

        static void PocMain()
        {
            // Export();
            // Console.WriteLine("--------------------------------------------------------------");
            // Console.WriteLine("--------------------------------------------------------------");
            // Import();
            // Komt overeen

            // var lines = File.ReadAllLines(@"C:\Users\Dirk-Jan\Dropbox\S6\Fitness Prestaties.txt");
            // var importer = new TextDataExporter();
            // var oefeningen = importer.ReadAllOefeningenWithPrestatiesFromLines(lines);
            // PrintAllOefeningen(oefeningen);
            // Import data juist en print het juist
        }

        static void Import()
        {
            var importer = new TextDataExporter();
            var oefeningen = importer.ReadAllOefeningenWithPrestatiesFromLines(ExportToLines());
            PrintAllOefeningen(oefeningen);
        }
        
        static List<string> ExportToLines()
        {
            var exporter = new DatabaseDataExporter();
            var oefeningen = exporter.GetAllOefeningenWithPrestaties();
            var lines = new List<string>();
            foreach (var oefening in oefeningen)
            {
                lines.Add($"Naam: {oefening.Naam}");
                lines.Add($"Omschrijving: {oefening.Omschrijving}");
                foreach (var prestatie in oefening.Prestaties)
                {
                    var datumFormat = "dd-MM-yyyyTHH:mm:ss";
                    var datum = prestatie.Datum.ToString(datumFormat);
                    var gewicht = prestatie.Gewicht.ToString() ?? "-";
                    var prestatieString = $"{datum}|{gewicht}|{prestatie.Herhalingen}|{prestatie.Opmerking}";
                    lines.Add(prestatieString);
                }
            }

            return lines;
        }

        static void Export()
        {
            var exporter = new DatabaseDataExporter();
            var oefeningen = exporter.GetAllOefeningenWithPrestaties();
            PrintAllOefeningen(oefeningen);
        }
        
        static void PrintAllOefeningen(IEnumerable<Oefening> oefeningen)
        {
            foreach (var oefening in oefeningen)
            {
                Console.WriteLine($"Naam: {oefening.Naam}");
                Console.WriteLine($"Omschrijving: {oefening.Omschrijving}");
                foreach (var prestatie in oefening.Prestaties)
                {
                    var datumFormat = "dd-MM-yyyyTHH:mm:ss";
                    var datum = prestatie.Datum.ToString(datumFormat);
                    var gewicht = prestatie.Gewicht.ToString() ?? "-";
                    var prestatieString = $"{datum}|{gewicht}|{prestatie.Herhalingen}|{prestatie.Opmerking}";
                    Console.WriteLine(prestatieString);
                }
            }
        }
    }
}