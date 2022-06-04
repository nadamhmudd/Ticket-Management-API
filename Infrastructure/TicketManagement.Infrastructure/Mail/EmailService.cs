global using TicketManagement.Application.Interfaces;
global using TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

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

        public async Task SendEmail(Email email)
        {
            var emailToSend = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_emailSettings.Email),
                Subject = email.Subject
            };

            emailToSend.From.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.Email));
            
            emailToSend.To.Add(MailboxAddress.Parse(email.To));
            
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = email.Body };

            //send email
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(_emailSettings.Host, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                
                emailClient.Authenticate(_emailSettings.Email, _emailSettings.Password);
                
                var response = await emailClient.SendAsync(emailToSend);

                emailClient.Disconnect(true);
            }
        }
    }
}
