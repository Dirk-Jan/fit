﻿using System;
using System.Linq;
using System.Threading.Tasks;
using BFF.Commands;
using BFF.Constants;
using BFF.Models;
using BFF.Repositories.Abstractions;
using BFF.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Minor.Miffy.MicroServices.Commands;

namespace BFF.Controllers
{
    [ApiController]
    [Route(Routes.Oefeningen)]
    public class OefeningController : Controller
    {
        private readonly IOefeningRepository _oefeningRepository;
        private readonly IPrestatieRepository _prestatieRepository;
        private readonly ICommandPublisher _commandPublisher;

        public OefeningController(
            IOefeningRepository oefeningRepository, 
            IPrestatieRepository prestatieRepository, 
            ICommandPublisher commandPublisher)
        {
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
                Omschrijving = oefening.Omschrijving
            };

            var prestatieDagen = _prestatieRepository.GetLatestsXDays(oefening.Id, 1000);

            oefeningViewModel.PrestatieDagen = prestatieDagen.ToList();
            
            return Json(oefeningViewModel);
        }

        [HttpPost]
        [Authorize(Policy = AuthPolicies.KanOefeningenToevoegenPolicy)]
        public async Task<IActionResult> Add(Oefening oefening)
        {
            // _oefeningRepository.Add(oefening);
            var command = new MaakOefeningAanCommand
            {
                Oefening = oefening
            };
            await _commandPublisher.PublishAsync<MaakOefeningAanCommand>(command);
            
            return Ok();
        }
    }
}