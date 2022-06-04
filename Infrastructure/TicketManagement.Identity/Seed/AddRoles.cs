global using Microsoft.AspNetCore.Identity;
global using TicketManagement.Application.Constants;

namespace TicketManagement.Identity.Seed
{
    public static class AddRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            foreach (string role in Enum.GetNames(typeof(IdentityRoles)))
            {
                roleManager.CreateAsync(new IdentityRole(role)).GetAwaiter().GetResult();
            }
        }
    }
}
