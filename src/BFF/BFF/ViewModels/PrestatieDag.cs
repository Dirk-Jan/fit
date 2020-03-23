using System;
using System.Collections.Generic;
using BFF.Models;

namespace BFF.ViewModels
{
    public class PrestatieDag
    {
        public DateTime Datum { get; set; }
        public IEnumerable<Prestatie> Prestaties { get; set; }
    }
}