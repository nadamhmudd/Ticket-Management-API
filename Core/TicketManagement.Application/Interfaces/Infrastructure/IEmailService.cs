using TicketManagement.Application.Models.Mail;

namespace TicketManagement.Application.Interfaces.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
