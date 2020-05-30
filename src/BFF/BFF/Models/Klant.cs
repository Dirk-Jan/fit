using System;

namespace BFF.Models
{
    public class Klant
    {
        public Guid Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
    }
}