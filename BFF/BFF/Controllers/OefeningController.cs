using BFF.Constants;
using BFF.Models;
using BFF.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Controllers
{
    [Route(Routes.Oefeningen)]
    public class OefeningController : Controller
    {
        private readonly IOefeningRepository _oefeningRepository;

        public OefeningController(IOefeningRepository oefeningRepository)
        {
            _oefeningRepository = oefeningRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_oefeningRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Oefening oefening)
        {
            _oefeningRepository.Add(oefening);
            return Ok();
        }
    }
}