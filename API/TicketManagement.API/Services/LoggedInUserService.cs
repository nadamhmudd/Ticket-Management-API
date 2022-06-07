using System.Security.Claims;
using TicketManagement.Application.Interfaces;
using TicketManagement.Application.Models;

namespace TicketManagement.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor, IAuthenticationService authService)
        {
           var userId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            User   = authService.GetUserAsync(userId).Result;
        }

        public UserDto User { get; }
    }
}
