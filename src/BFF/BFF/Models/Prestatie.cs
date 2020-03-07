using System;

namespace BFF.Models
{
    public class Prestatie
    {
        public Guid Id { get; set; }
        public Guid OefeningId { get; set; }
        public DateTime Datum { get; set; }
        public double Gewicht { get; set; }
        public int Set1 { get; set; }
        public int Set2 { get; set; }
        public int Set3 { get; set; }
        public string Opmerking { get; set; }
    }
}