using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace IdentityServer4.Quickstart.UI.AccountManagement
{
    public class ClaimsManagementViewModel
    {
        public IEnumerable<Claim> Claims { get; set; } = new List<Claim>();
        
        [Required]
        public string UserId { get; set; }
        
        [Required]
        [DisplayName("Type")]
        public string ClaimType { get; set; }
        
        [Required]
        [DisplayName("Value")]
        public string ClaimValue { get; set; }

        public string Username { get; set; }
    }
}