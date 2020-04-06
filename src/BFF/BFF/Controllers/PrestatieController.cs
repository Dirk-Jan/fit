using System;
using BFF.Constants;
using BFF.Models;
using BFF.Repositories.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Controllers
{
    [ApiController]
    [Route(Routes.Prestaties)]
    public class PrestatieController : Controller
    {
        private readonly IPrestatieRepository _prestatieRepository;

        public PrestatieController(IPrestatieRepository prestatieRepository)
        {
            _prestatieRepository = prestatieRepository;
        }
        
        [HttpPost]
        [Authorize(Policy = AuthPolicies.KanPrestatiesToevoegenPolicy)]
        public IActionResult Add(Prestatie prestatie)
        {
            prestatie.Datum = DateTime.Now;
            _prestatieRepository.Add(prestatie);
            return Ok(prestatie);
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