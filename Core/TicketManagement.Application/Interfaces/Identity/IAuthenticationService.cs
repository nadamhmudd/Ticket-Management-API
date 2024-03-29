﻿namespace TicketManagement.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task AddRoleAsync(AddRoleRequest request);
        Task<UserDto> GetUserAsync(string id);
    }
}
