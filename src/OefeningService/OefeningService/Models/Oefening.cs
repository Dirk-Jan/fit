using System;
using OefeningService.Enums;

namespace OefeningService.Models
{
    public class Oefening
    {
        public Guid Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public Spiergroep? Spiergroep { get; set; }
    }
}