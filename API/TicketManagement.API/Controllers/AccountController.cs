global using Microsoft.AspNetCore.Authorization;
global using TicketManagement.Application.Constants;
using TicketManagement.Application.Interfaces;
using TicketManagement.Application.Models;

namespace TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Props / Vars
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Ctor
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        #endregion

        #region Actions
        [HttpGet("{id}", Name="GetUserInfo"), Authorize()]
        public async Task<ActionResult<UserDto>> GetUserAsync(string id)
        {
            return Ok(await _authenticationService.GetUserAsync(id));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("addrole"), Authorize(Roles = SD.Role_Admin)]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleRequest request)
        {
            await _authenticationService.AddRoleAsync(request);

            return Ok(request);
        }
        #endregion
    }
}