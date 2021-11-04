using System;
using System.Collections.Generic;
using BFF.Enums;

namespace BFF.ViewModels
{
    public class OefeningViewModel
    {
        public Guid Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public Spiergroep? Spiergroep { get; set; }
        public ICollection<PrestatieDag> PrestatieDagen { get; set; } = new List<PrestatieDag>();
    }
}