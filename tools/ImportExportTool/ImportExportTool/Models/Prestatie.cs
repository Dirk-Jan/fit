using System;

namespace ImportExportTool.Models
{
    public class Prestatie
    {
        public Guid Id { get; set; }
        public Guid OefeningId { get; set; }
        // public Guid KlantId { get; set; }
        public DateTime Datum { get; set; }
        public double? Gewicht { get; set; }
        public double Herhalingen { get; set; }
        public string Opmerking { get; set; }
    }
}