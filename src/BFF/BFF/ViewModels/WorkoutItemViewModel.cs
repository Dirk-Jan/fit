using System.Collections.Generic;
using BFF.Models;

namespace BFF.ViewModels
{
    public class WorkoutItemViewModel
    {
        public string OefeningNaam { get; set; }
        public ICollection<Prestatie> Prestaties { get; set; }
    }
}