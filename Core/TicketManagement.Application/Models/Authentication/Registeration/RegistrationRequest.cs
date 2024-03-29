﻿using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Application.Models
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password), MinLength(6)]
        public string Password { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }
    }
}
