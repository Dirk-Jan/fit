using System;
using System.Collections.Generic;
using BFF.Models;

namespace BFF.ViewModels
{
    public class WorkoutItemViewModel
    {
        public Guid OefeningId { get; set; }
        public string OefeningNaam { get; set; }
        public ICollection<Prestatie> Prestaties { get; set; }
    }
}