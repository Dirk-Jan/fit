using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BFF.Commands;
using BFF.Constants;
using BFF.Models;
using BFF.Repositories.Abstractions;
using BFF.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Minor.Miffy;

namespace BFF.Controllers
{
    [ApiController]
    [Route("SmartwatchFit")]
    public class SmartwatchFitController : BaseController
    {
        private readonly IOefeningRepository _oefeningRepository;
        private readonly ICommandPublisher _commandPublisher;
        private readonly Guid _klantIdDirkJan = Guid.Parse("979f7437-f7f3-4662-7485-08d80d5821ea");

        public SmartwatchFitController(IOefeningRepository oefeningRepository, ICommandPublisher commandPublisher)
        {
            _oefeningRepository = oefeningRepository;
            _commandPublisher = commandPublisher;
        }

        [HttpGet]
        [Route("Oefeningen")]
        public IActionResult GetAll()
        {
            // if (!ApiKeyIsValid())
            // {
            //     return Unauthorized();
            // }
            
            var oefeningen = _oefeningRepository.GetAllWithSomePrestaties(_klantIdDirkJan);
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
        
        [HttpPost]
        [Route("Prestaties")]
        public async Task<IActionResult> AddPrestatie(Prestatie prestatie)
        {
            if (!ApiKeyIsValid())
            {
                return Unauthorized();
            }
            
            prestatie.Datum = DateTime.Now;
            prestatie.KlantId = _klantIdDirkJan;

            var command = new RegistreerPrestatieCommand
            {
                Prestatie = prestatie
            };
            var result = await _commandPublisher.PublishAsync<RegistreerPrestatieCommand>(command);

            return Ok();
        }

        private bool ApiKeyIsValid()
        {
            var validApiKey = Environment.GetEnvironmentVariable(EnvNames.ApiKeySmartwatchController);
            if (validApiKey is null)
                return false;
            
            var validApiKeyAsHashString = GetHashSha256(validApiKey);
            var apiKeyInRequest = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "FitKey").Value.ToList().FirstOrDefault();
            return apiKeyInRequest == validApiKeyAsHashString;
        }
        
        private static string GetHashSha256(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var hasher = new SHA256Managed();
            var hash = hasher.ComputeHash(bytes);
            var hashString = string.Empty;
            foreach (var @byte in hash)
            {
                hashString += $"{@byte:x2}";
            }
            return hashString;
        }
    }
}