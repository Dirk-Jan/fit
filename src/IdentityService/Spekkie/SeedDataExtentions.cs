using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Spekkie.Data;
using Spekkie.Models;

namespace Spekkie
{
    public static class SeedDataExtentions
    {
        public static void EnsureDefaultUsersAccounts(this IServiceCollection serviceCollection, IEnumerable<SeedUserAccount> userAccounts)
        {
            using ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            using IServiceScope scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>()
                .CreateLogger<Startup>();

            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            
            context.Database.EnsureCreated();

            EnsureSeedData(userManager, logger, userAccounts);
        }
        
        private static void EnsureSeedData(UserManager<ApplicationUser> userManager, ILogger logger, IEnumerable<SeedUserAccount> userAccounts)
        {
            foreach (SeedUserAccount userAccount in userAccounts)
            {
                logger.LogDebug($"Checking if user {userAccount.Username} exists");

                var user = userManager.FindByNameAsync(userAccount.Username).Result;

                if (user == null)
                {
                    logger.LogInformation($"Attempting to create user {userAccount.Username}");
                    user = new ApplicationUser
                    {
                        UserName = userAccount.Username
                    };

                    var result = userManager.CreateAsync(user, userAccount.Password).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userManager.AddClaimsAsync(user, userAccount.Claims).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    logger.LogInformation($"User {userAccount.Username} successfully created!");
                }
                else
                {
                    logger.LogInformation($"User {userAccount.Username} already exists, skipping");
                }
            };
        }
    }
    
    public class SeedUserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Claim[] Claims { get; set; }
    }
}