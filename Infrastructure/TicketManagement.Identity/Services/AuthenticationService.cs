using TicketManagement.Application.Interfaces;
using TicketManagement.Application.Models;
using TicketManagement.Identity.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using TicketManagement.Identity.Helpers;

namespace TicketManagement.Identity.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        #region Props/ Vars
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        #endregion

        #region Ctor
        public AuthenticationService(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }
        #endregion

        #region Actions
        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            if (await _userManager.FindByNameAsync(request.UserName) is not null)
                throw new Exception($"Username '{request.UserName}' already exists.");

            if (await _userManager.FindByNameAsync(request.Email) is not null)
                throw new Exception($"Email {request.Email } already exists.");

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            await _userManager.AddToRoleAsync(user, Enum.GetName(typeof(IdentityRoles), IdentityRoles.User));  //by default

            if (!result.Succeeded)
            {
                throw new Exception($"{result.ErrorDescription()}");
            }

            return new RegistrationResponse() { UserId = user.Id };
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                throw new Exception($"User with {request.Email} not found.");

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            var jwtSecurityToken = await JwtHandler.GenerateToken(user, 
                                        userManager: _userManager, 
                                        jwtSettings: _jwtSettings);

            return new AuthenticationResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
        }

        public async Task AddRoleAsync(AddRoleRequest request)
        {
            var rule = Enum.GetName(typeof(IdentityRoles), request.Role);
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(rule))
                throw new Exception("Invalid user ID or Role");

            if (await _userManager.IsInRoleAsync(user, rule))
                throw new Exception("User already assigned to this role");

            var result = await _userManager.AddToRoleAsync(user, rule);

            if (!result.Succeeded)
                throw new Exception("Something went wrong");
        }
        #endregion
    }
}