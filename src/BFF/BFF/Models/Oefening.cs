using System;
using System.Collections.Generic;
using BFF.Enums;

namespace BFF.Models
{
    public class Oefening
    {
        public Guid Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public ICollection<Prestatie> Prestaties { get; set; }
        public Spiergroep? Spiergroep { get; set; }
    }
}