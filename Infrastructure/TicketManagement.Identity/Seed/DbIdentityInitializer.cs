using TicketManagement.Application.Interfaces;

namespace TicketManagement.Identity.Seed
{
    public class DbIdentityInitializer : IDbIdentityInitializer
    {
        #region Props / Vars
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Ctor
        public DbIdentityInitializer(RoleManager<IdentityRole> roleManager, IAuthenticationService authenticationService)
        {
            _roleManager = roleManager;
            _authenticationService = authenticationService;
        } 
        #endregion
        
        public async Task Initialize()
        {
            if (!_roleManager.RoleExistsAsync(Enum.GetName(typeof(IdentityRoles), IdentityRoles.Admin))
                             .GetAwaiter().GetResult())
            {
                await AddRoles.SeedAsync(_roleManager);

                //if roles are not created, then we will create admin user as well
                await CreateFirstAdmin.SeedAsync(_authenticationService);
            }
        }
    }
}
