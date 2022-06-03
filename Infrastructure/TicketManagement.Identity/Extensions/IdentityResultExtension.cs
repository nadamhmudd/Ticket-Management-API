using Microsoft.AspNetCore.Identity;

namespace TicketManagement.Identity
{
    internal static class IdentityResultExtension
    {
        internal static string ErrorDescription(this IdentityResult identityResult) 
            => $"Failed, {string.Join(",", identityResult.Errors.Select((IdentityError x) => x.Description).ToList())}";
    }
}
