using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using Spekkie.Constants;

namespace Spekkie
{
    public static class SeedData
    {
        public static IEnumerable<SeedUserAccount> DefaultUserAccounts => new[]
        {
            new SeedUserAccount
            {
                Username = "admin",
                Password = "Pass123$",
                Claims = new []
                {
                    new Claim(JwtClaimTypes.Name, "Admin"),
                    new Claim(AuthClaims.SpekkieAccountViewAll, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieAccountRemove, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieAccountClaimViewAll, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieAccountClaimAdd, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieAccountClaimRemove, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieSettingsViewAll, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieSettingsCanEnableDisableRegister, AuthClaims.True)
                }
            }
        };
    }
}