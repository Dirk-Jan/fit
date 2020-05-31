using System;
using System.Linq;
using System.Threading.Tasks;
using BFF.Commands;
using BFF.Constants;
using BFF.Models;
using BFF.Repositories.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minor.Miffy.MicroServices.Commands;

namespace BFF.Controllers
{
    [ApiController]
    [Route(Routes.Prestaties)]
    public class PrestatieController : BaseController
    {
        private readonly IPrestatieRepository _prestatieRepository;
        private readonly ICommandPublisher _commandPublisher;

        public PrestatieController(IPrestatieRepository prestatieRepository, ICommandPublisher commandPublisher)
        {
            _prestatieRepository = prestatieRepository;
            _commandPublisher = commandPublisher;
        }
        
        [HttpPost]
        [Authorize(Policy = AuthPolicies.KanPrestatiesToevoegenPolicy)]
        public async Task<IActionResult> Add(Prestatie prestatie)
        {
            prestatie.Datum = DateTime.Now;
            prestatie.KlantId = GetKlantIdFromToken();

            var command = new RegistreerPrestatieCommand
            {
                Prestatie = prestatie
            };
            var result = await _commandPublisher.PublishAsync<RegistreerPrestatieCommand>(command);

            return Ok(result.Prestatie);
        }

        // [HttpGet]
        // [Route("nextday/{oefeningId}/{lastDay}")]
        // public IActionResult GetNextDay(Guid oefeningId, DateTime lastDay)
        // {
        //     
        //     return Ok();
        // }
    }
}