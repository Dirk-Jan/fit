using System;
using BFF.Enums;

namespace BFF.ViewModels
{
    public class PrestatieSmartwatchViewModel
    {
        public Guid OefeningId { get; set; }
        public DateTime Datum { get; set; }
        public double? Gewicht { get; set; }
        public double? Herhalingen { get; set; }
        public OefeningZwaarte? OefeningZwaarte { get; set; }
    }
}