using System;
using System.Linq;
using BFF.Constants;
using BFF.Models;
using BFF.Repositories.Abstractions;
using BFF.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BFF.Controllers
{
    [ApiController]
    [Route(Routes.Oefeningen)]
    public class OefeningController : Controller
    {
        private readonly IOefeningRepository _oefeningRepository;
        private readonly IPrestatieRepository _prestatieRepository;

        public OefeningController(IOefeningRepository oefeningRepository, IPrestatieRepository prestatieRepository)
        {
            _oefeningRepository = oefeningRepository;
            _prestatieRepository = prestatieRepository;
        }
        
        [HttpGet]
        [Authorize(Policy = AuthPolicies.KanOefeningenZienPolicy)]
        public IActionResult GetAll()
        {
            return Json(_oefeningRepository.GetAll());
        }
        
        [HttpGet]
        [Route("{id}")]
        [Authorize(Policy = AuthPolicies.KanOefeningenZienPolicy)]
        public IActionResult GetById(Guid id)
        {
            var oefening = _oefeningRepository.GetById(id);
            var oefeningViewModel = new OefeningViewModel
            {
                Id = oefening.Id,
                Naam = oefening.Naam,
                Omschrijving = oefening.Omschrijving
            };

            var prestaties = _prestatieRepository.GetByOefeningId(id);
            // var groupedPrestaties = prestaties.GroupBy(x => x.Datum.Date);
            if (prestaties.Count() > 0)
            {
                var latestDate = prestaties.Max(x => x.Datum).Date;
                var filteredPrestaties = prestaties.Where(x => x.Datum.Date == latestDate);

                oefeningViewModel.PrestatieDagen.Add(new PrestatieDag
                {
                    Datum = latestDate,
                    Prestaties = filteredPrestaties
                });
            }
            
            return Json(oefeningViewModel);
        }

        [HttpPost]
        [Authorize(Policy = AuthPolicies.KanOefeningenToevoegenPolicy)]
        public IActionResult Add(Oefening oefening)
        {
            _oefeningRepository.Add(oefening);
            return Ok();
        }
    }
}