using System;
using System.Collections.Generic;
using BFF.Enums;

namespace BFF.ViewModels
{
    public class OefeningSmartwatchViewModel
    {
        public Guid Id { get; set; }
        public string Naam { get; set; }
        public Spiergroep? Spiergroep { get; set; }
        public IList<PrestatieSmartwatchViewModel> Prestaties { get; set; } = new List<PrestatieSmartwatchViewModel>();
        public PrestatieSmartwatchViewModel LaatstePrestatie { get; set; }
    }
}