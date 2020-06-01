using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spekkie.Constants;
using Spekkie.Models;

namespace IdentityServer4.Quickstart.UI.AccountManagement
{
    public class AccountManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        public AccountManagementController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpGet]
        [Authorize(Policy = AuthPolicies.SpekkieAccountViewAllPolicy)]
        public IActionResult GetAllAccounts()
        {
            var users = _userManager.Users.ToList();
            return View("UserList", users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = AuthPolicies.SpekkieAccountRemovePolicy)]
        public async Task<IActionResult> RemoveAccountConformation(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var viewModel = new AccountRemoveConformationViewModel
            {
                UserId = user.Id,
                Name = user.UserName
            };
            return View("AccountRemoveConformationView", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = AuthPolicies.SpekkieAccountRemovePolicy)]
        public async Task<IActionResult> RemoveAccount([FromForm] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var identityResult = await _userManager.DeleteAsync(user);
            if (!identityResult.Succeeded)
            {
                ModelState.AddModelError("ASP NET Core Identity", "Something went wrong when attempting to delete an account");
            }
            
            var users = _userManager.Users.ToList();
            return View("UserList", users);
        }
        
        [HttpGet]
        [Authorize(Policy = AuthPolicies.SpekkieAccountClaimViewAllPolicy)]
        public async Task<IActionResult> ManageClaims(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var claims = await _userManager.GetClaimsAsync(user);
            var viewModel = new ClaimsManagementViewModel
            {
                UserId = user.Id,
                Claims = claims,
                Username = user.UserName
            };
            return View("ClaimsManagement", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = AuthPolicies.SpekkieAccountClaimAddPolicy)]
        public async Task<IActionResult> AddClaim(ClaimsManagementViewModel viewModel)
        {
            var user = await _userManager.FindByIdAsync(viewModel.UserId);
            
            if (ModelState.IsValid)
            {
                var identityResult = await _userManager.AddClaimAsync(user, new Claim(viewModel.ClaimType, viewModel.ClaimValue));
                if (identityResult.Succeeded)
                {
                    viewModel.ClaimType = string.Empty;
                    viewModel.ClaimValue = string.Empty;
                }
                else
                {
                    ModelState.AddModelError("ASP NET Core Identity", "Something went wrong when attempting to add a claim");
                }
            }

            viewModel.Claims = await _userManager.GetClaimsAsync(user);
            return View("ClaimsManagement", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = AuthPolicies.SpekkieAccountClaimRemovePolicy)]
        public async Task<IActionResult> RemoveClaim([FromForm] string userId, string claimTypeToRemove, string claimValueToRemove)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var identityResult = await _userManager.RemoveClaimAsync(user, new Claim(claimTypeToRemove, claimValueToRemove));
            if (!identityResult.Succeeded)
            {
                ModelState.AddModelError("ASP NET Core Identity", "Something went wrong when attempting to remove a claim");
            }

            var viewModel = new ClaimsManagementViewModel
            {
                UserId = userId,
                Claims = await _userManager.GetClaimsAsync(user),
                Username = user.UserName
            };
            return View("ClaimsManagement", viewModel);
        }
    }
}