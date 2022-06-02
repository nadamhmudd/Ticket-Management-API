using TicketManagement.Application.Models.Mail;

namespace TicketManagement.Application.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
