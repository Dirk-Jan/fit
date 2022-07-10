using System.Collections.Generic;
using System.Linq;
using BFF.Repositories.Abstractions;
using BFF.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Controllers
{
    [ApiController]
    [Route("SmartwatchFit")]
    public class SmartwatchFitController : BaseController
    {
        private readonly IOefeningRepository _oefeningRepository;
        private readonly IPrestatieRepository _prestatieRepository;

        public SmartwatchFitController(IOefeningRepository oefeningRepository, IPrestatieRepository prestatieRepository)
        {
            _oefeningRepository = oefeningRepository;
            _prestatieRepository = prestatieRepository;
        }
        
        [HttpGet]
        // [Authorize(Policy = AuthPolicies.KanOefeningenZienPolicy)]
        [Route("Oefeningen")]
        public IActionResult GetAll()
        {
            var oefeningen = _oefeningRepository.GetAllWithSomePrestaties();
            var oefeningViewModels = new List<OefeningSmartwatchViewModel>();
            foreach (var oefening in oefeningen)
            {
                var oefeningViewModel = new OefeningSmartwatchViewModel();
                oefeningViewModel.Id = oefening.Id;
                oefeningViewModel.Naam = oefening.Naam;
                oefeningViewModel.Spiergroep = oefening.Spiergroep;
                oefeningViewModel.Prestaties = new List<PrestatieSmartwatchViewModel>();
                foreach (var prestatie in oefening.Prestaties)
                {
                    var presatieViewModel = new PrestatieSmartwatchViewModel();
                    presatieViewModel.Datum = prestatie.Datum;
                    presatieViewModel.Gewicht = prestatie.Gewicht;
                    presatieViewModel.Herhalingen = prestatie.Herhalingen;
                    presatieViewModel.OefeningZwaarte = prestatie.OefeningZwaarte;
                    oefeningViewModel.Prestaties.Add(presatieViewModel);
                }

                oefeningViewModel.LaatstePrestatie = oefeningViewModel.Prestaties.FirstOrDefault(prestatie => prestatie.Datum == oefeningViewModel.Prestaties.Max(x => x.Datum));
                
                oefeningViewModels.Add(oefeningViewModel);
            }
            
            return Json(oefeningViewModels);
        }
    }
}