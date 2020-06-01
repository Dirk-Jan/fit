using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spekkie;
using Spekkie.Constants;

namespace IdentityServer4.Quickstart.UI.Settings
{
    public class SettingsController : Controller
    {
        [HttpGet]
        [Authorize(Policy = AuthPolicies.SpekkieSettingsViewAllPolicy)]
        public IActionResult ViewSettings()
        {
            return View("Settings");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = AuthPolicies.SpekkieSettingsViewAllPolicy)]
        [Authorize(Policy = AuthPolicies.SpekkieSettingsCanEnableDisableRegisterPolicy)]
        public IActionResult EnableRegister()
        {
            Startup.RegisterEnabled = true;
            return View("Settings");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = AuthPolicies.SpekkieSettingsViewAllPolicy)]
        [Authorize(Policy = AuthPolicies.SpekkieSettingsCanEnableDisableRegisterPolicy)]
        public IActionResult DisableRegister()
        {
            Startup.RegisterEnabled = false;
            return View("Settings");
        }
    }
}