global using TicketManagement.Application.Interfaces.Infrastructure;
global using TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Options;

namespace TicketManagement.Infrastructure
{
    public class EmailService : IEmailService
    {
        #region Props / Vars
        private EmailSettings _emailSettings { get; }
        #endregion

        #region Constructors(s)
        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _emailSettings = mailSettings.Value;
        } 
        #endregion

        public async Task<bool> SendEmail(Email email)
        {
            //var client = new SendGridClient(_emailSettings.ApiKey);

            //var subject = email.Subject;
            //var to = new EmailAddress(email.To);
            //var emailBody = email.Body;

            //var from = new EmailAddress
            //{
            //    Email = _emailSettings.FromAddress,
            //    Name = _emailSettings.FromName
            //};

            //var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            //var response = await client.SendEmailAsync(sendGridMessage);

            //if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            //    return true;

            return false;
        }
    }
}
