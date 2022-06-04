using TicketManagement.Application.Models.Mail;

namespace TicketManagement.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(Email email);
    }
}
