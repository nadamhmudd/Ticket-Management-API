using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Application.Models.Authentication
{
    public class RegistrationRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(6)]
        public string UserName { get; set; }

        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Phone]
        public string Mobile { get; set; }
    }
}
