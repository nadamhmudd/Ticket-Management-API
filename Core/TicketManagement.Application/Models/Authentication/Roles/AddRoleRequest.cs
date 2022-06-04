using System.ComponentModel.DataAnnotations;
using TicketManagement.Application.Constants;

namespace TicketManagement.Application.Models
{
    public class AddRoleRequest
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public IdentityRoles Role { get; set; }
    }
}
