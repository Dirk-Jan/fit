using System;
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
                Username = Environment.GetEnvironmentVariable(EnvNames.AdminUsername) ?? "admin",
                Password = Environment.GetEnvironmentVariable(EnvNames.AdminPassword) ?? "Pass123$",
                Claims = new []
                {
                    new Claim(JwtClaimTypes.Name, "Admin"),
                    new Claim(AuthClaims.SpekkieAccountViewAll, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieAccountRemove, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieAccountClaimViewAll, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieAccountClaimAdd, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieAccountClaimRemove, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieSettingsViewAll, AuthClaims.True),
                    new Claim(AuthClaims.SpekkieSettingsCanEnableDisableRegister, AuthClaims.True),
                    
                    new Claim(FitAuthClaims.FitOefeningAdd, FitAuthClaims.True),
                    new Claim(FitAuthClaims.FitOefeningRead, FitAuthClaims.True),
                    new Claim(FitAuthClaims.FitOefeningEdit, FitAuthClaims.True),
                    new Claim(FitAuthClaims.FitOefeningPrestatieAdd, FitAuthClaims.True),
                    new Claim(FitAuthClaims.FitOefeningPrestatieRead, FitAuthClaims.True),
                }
            }
        };
    }
}