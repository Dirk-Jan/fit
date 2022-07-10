using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImportExportTool.Commands;
using ImportExportTool.Logic;
using ImportExportTool.Models;
using Microsoft.Extensions.Logging;
using Minor.Miffy;
using Minor.Miffy.MicroServices;
using Minor.Miffy.MicroServices.Abstractions;
using Minor.Miffy.MicroServices.Serialization;
using Minor.Miffy.RabbitMQBus;
using RabbitMQ.Client;

namespace ImportExportTool
{
    class Program
    {
        private const string QueueName = "Fit.ImportExportTool.Queue";
        
        static async Task Main(string[] args)
        {
            // Console.Write("Enter RabbitMQ connection string: ");
            // var connectionString = Console.ReadLine();
            // Console.WriteLine($"Using RabbitMQ connection string: '{connectionString}'");
            // Environment.SetEnvironmentVariable("BROKER_CONNECTION_STRING", connectionString);
            //
            // Console.WriteLine();
            //
            // Console.Write("Enter MSSQL connection string: ");
            // connectionString = Console.ReadLine();
            // Console.WriteLine($"Using MSSQL connection string: '{connectionString}'");
            // Environment.SetEnvironmentVariable("DB_CONNECTION_STRING", connectionString);
            //
            // Console.WriteLine();

            using var loggerFactory = LoggerFactory.Create(configure =>
            {
                configure.AddConsole().SetMinimumLevel(LogLevel.Debug);
            });

            var connectionFactory = new ConnectionFactory();
            var contextBuilder = new RabbitMQContextBuilder(connectionFactory)
                .ReadFromEnvironmentVariables();
            using IBusContext<IConnection> busContext = contextBuilder.CreateContext();

            using ICommandPublisher commandPublisher = new CommandPublisher(loggerFactory.CreateLogger<CommandPublisher>(), busContext.CreateCommandSender(), new JsonSerialization(), new UnicodeEncoding());

            var klantId = new Guid("979F7437-F7F3-4662-7485-08D80D5821EA");

            // Export();
            // await ImportDataIntoSystemFromFile(commandPublisher, klantId, @"C:\Users\Dirk-Jan\Dropbox\S6\prestaties beide.txt");
            AddPrestatiesByUserInput(commandPublisher, klantId);
        }
        
        


        static async Task ImportDataIntoSystemFromFile(ICommandPublisher commandPublisher, Guid klantId, string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var exporter = new TextDataExporter();
            var oefeningen = exporter.ReadAllOefeningenWithPrestatiesFromLines(lines);
            
            var importer = new DataImporter(commandPublisher);
            await importer.ImportOefeningenIntoSystem(oefeningen.ToList(), klantId);
        }
        
        
        
        // POCs below

        static void AddPrestatiesByUserInput(ICommandPublisher commandPublisher, Guid klantId)
        {
            var exporter = new DatabaseDataExporter();
            var oefeningen = exporter.GetAllOefeningenWithPrestaties()
                .OrderBy(x => x.Naam)
                .ToList();
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Oefeningen:");
            foreach (var oefening in oefeningen)
            {
                Console.WriteLine($"Guid: {oefening.Id}, Naam: '{oefening.Naam}'");
            }

            Console.WriteLine("Voer gegevens in:");

            for (;;)
            {
                Console.Write("Datum (dd-MM-yyyy): ");
                var datumAsString = Console.ReadLine();
                if (!DateTime.TryParseExact(datumAsString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datum))
                {
                    Console.WriteLine("Datum is niet gelding, probeer opnieuw");
                    continue;
                }
                var now = DateTime.Now;
                datum = new DateTime(datum.Year, datum.Month, datum.Day, now.Hour, now.Minute, now.Second);
                
                for (;;)
                {
                    Console.Write("Oefening Id (Guid): ");
                    var guidAsString = Console.ReadLine();
                    if (!Guid.TryParse(guidAsString, out Guid oefeningId))
                    {
                        Console.WriteLine("Oefening Id is niet een gelding Guid, probeer opnieuw");
                        continue;
                    }

                    for (;;)
                    {
                        Console.Write("Gewicht: ");
                        var gewichtAsString = Console.ReadLine();
                        double? gewicht = null;
                        if (!string.IsNullOrWhiteSpace(gewichtAsString))
                        {
                            if (!double.TryParse(gewichtAsString, out double outGewicht))
                            {
                                Console.WriteLine("Gewicht is niet gelding, probeer opnieuw");
                                continue;
                            }
                            gewicht = outGewicht;
                        }

                        Console.Write("Herhalingen: ");
                        var herhalingenAsString = Console.ReadLine();
                        double? herhalingen = null;
                        if (!string.IsNullOrWhiteSpace(herhalingenAsString))
                        {
                            if (!double.TryParse(herhalingenAsString, out double outHerhalingen))
                            {
                                Console.WriteLine("Herhalingen is niet gelding, probeer opnieuw");
                                continue;
                            }
                            herhalingen = outHerhalingen;
                        }
                
                        Console.Write("Sets: ");
                        var setsAsString = Console.ReadLine();
                        int? sets = null;
                        if (!string.IsNullOrWhiteSpace(setsAsString))
                        {
                            if (!int.TryParse(setsAsString, out int outSets))
                            {
                                Console.WriteLine("Sets is niet gelding, probeer opnieuw");
                                continue;
                            }
                            sets = outSets;
                        }
                        
                        // Add prestatie
                        var prestatie = new Prestatie
                        {
                            KlantId = klantId,
                            OefeningId = oefeningId,
                            Datum = datum,
                            Gewicht = gewicht,
                            Herhalingen = herhalingen,
                            Sets = sets
                        };

                        var oefeningNaam = oefeningen.FirstOrDefault(x => x.Id == oefeningId)?.Naam;
                        Console.WriteLine("Prestatie");
                        Console.WriteLine($"  Oefening naam: '{oefeningNaam}'");
                        Console.WriteLine($"  Datum: '{datum.ToString("dd-MM-yyyy HH:mm:ss")}'");
                        Console.WriteLine($"  '{gewicht}' Kg x '{herhalingen}' Reps x '{sets}' Sets");
                        Console.WriteLine();
                        Console.WriteLine("Toevoegen? [y/n] ");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            commandPublisher.Publish(new RegistreerPrestatieCommand
                            {
                                Prestatie = prestatie
                            });
                        }
                        
                        Console.WriteLine($"Meer prestaties voor oefening {oefeningNaam} op datum {datumAsString}? [y/n] ");
                        if (Console.ReadKey().Key != ConsoleKey.Y)
                            break;
                    }

                    Console.WriteLine($"Meer prestaties op datum {datumAsString}? [y/n] ");
                    if (Console.ReadKey().Key != ConsoleKey.Y)
                        break;
                }
                Console.WriteLine($"Meer prestaties om in te voeren? [y/n] ");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                    break;
            }

            Console.WriteLine("Klaar.");
        }

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