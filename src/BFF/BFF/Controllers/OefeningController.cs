using System;
using System.Linq;
using System.Threading.Tasks;
using BFF.Commands;
using BFF.Constants;
using BFF.Models;
using BFF.Repositories.Abstractions;
using BFF.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minor.Miffy;

namespace BFF.Controllers
{
    [ApiController]
    [Route(Routes.Oefeningen)]
    public class OefeningController : BaseController
    {
        private readonly ILogger<OefeningController> _logger;
        private readonly IOefeningRepository _oefeningRepository;
        private readonly IPrestatieRepository _prestatieRepository;
        private readonly ICommandPublisher _commandPublisher;

        public OefeningController(ILogger<OefeningController> logger, IOefeningRepository oefeningRepository, IPrestatieRepository prestatieRepository, ICommandPublisher commandPublisher)
        {
            _logger = logger;
            _oefeningRepository = oefeningRepository;
            _prestatieRepository = prestatieRepository;
            _commandPublisher = commandPublisher;
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
                Omschrijving = oefening.Omschrijving,
                Spiergroep = oefening.Spiergroep,
            };

            var klantId = GetKlantIdFromToken();
            var prestatieDagen = _prestatieRepository.GetLatestsXDays(oefening.Id, klantId, 1000);

            oefeningViewModel.PrestatieDagen = prestatieDagen.ToList();
            
            return Json(oefeningViewModel);
        }

        [HttpPost]
        [Authorize(Policy = AuthPolicies.KanOefeningenToevoegenPolicy)]
        public async Task<IActionResult> Add(Oefening oefening)
        {
            var command = new MaakOefeningAanCommand
            {
                Oefening = oefening
            };
            var result = await _commandPublisher.PublishAsync<MaakOefeningAanCommand>(command);
            
            return Ok(result.Oefening.Id);
        }
        
        [HttpPut]
        [Authorize(Policy = AuthPolicies.KanOefeningenAanpassenPolicy)]
        public async Task<IActionResult> Edit(Oefening oefening)
        {
            await _commandPublisher.PublishAsync<PasOefeningAanCommand>(new PasOefeningAanCommand
            {
                Oefening = oefening
            });
            
            return Ok();
        }
    }
}