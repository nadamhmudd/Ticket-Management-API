using TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace TicketManagement.Identity.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "Nada",
                LastName = "Mahmoud",
                UserName = "nadamhmudd",
                Email = "nada@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Nada123*");
            }
        }
    }
}