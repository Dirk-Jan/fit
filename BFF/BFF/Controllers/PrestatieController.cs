using BFF.Constants;
using BFF.Models;
using BFF.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Controllers
{
    [Route(Routes.Prestaties)]
    public class PrestatieController : Controller
    {
        private readonly IPrestatieRepository _prestatieRepository;

        public PrestatieController(IPrestatieRepository prestatieRepository)
        {
            _prestatieRepository = prestatieRepository;
        }
        
        [HttpPost]
        public IActionResult Add(Prestatie prestatie)
        {
            _prestatieRepository.Add(prestatie);
            return Ok();
        }
    }
}