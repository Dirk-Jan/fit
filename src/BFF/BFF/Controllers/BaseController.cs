using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Controllers
{
    public class BaseController : Controller
    {
        public Guid GetKlantIdFromToken()
        {
            var claim = HttpContext.User.Identities.First().Claims.First(x => x.Type == "KlantId");
            var klantId = Guid.Parse(claim.Value);
            return klantId;
        }
    }
}