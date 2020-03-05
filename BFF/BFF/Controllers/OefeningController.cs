using Microsoft.AspNetCore.Mvc;

namespace BFF.Controllers
{
    public class OefeningController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}