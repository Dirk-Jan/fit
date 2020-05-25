using System;
using System.Collections;
using System.Collections.Generic;

namespace BFF.ViewModels
{
    public class WorkoutViewModel
    {
        public DateTime Datum { get; set; }
        public IEnumerable<WorkoutItemViewModel> WorkoutItems { get; set; }
    }
}