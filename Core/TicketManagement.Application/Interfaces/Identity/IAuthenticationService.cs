using TicketManagement.Application.Models.Authentication;

namespace TicketManagement.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    }
}
