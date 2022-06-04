using TicketManagement.Application.Interfaces;
using TicketManagement.Application.Models;

namespace TicketManagement.Identity.Seed
{
    public static class CreateFirstAdmin
    {
        public static async Task SeedAsync(IAuthenticationService authService)
        {
            var response = await authService.RegisterAsync(new RegistrationRequest()
            {
                FirstName = "APP",
                LastName = "Manager",
                UserName = "admin",
                Email = "Admin@test.com",
                Password = "Admin123*",
                PhoneNumber = "+201003748713"
            });

            await authService.AddRoleAsync(new AddRoleRequest()
            {
                UserId = response.UserId,
                Role   = IdentityRoles.Admin
            });
        }
    }
}