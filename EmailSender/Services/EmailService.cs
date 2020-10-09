using EmailSender.Extensions;
using EmailSender.Models;
using System.Net.Mail;

namespace EmailSender.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(EmailSettings settings)
        {
            _settings = settings;
        }

        public void Send(string email, string message)
        {
            using (var client = new SmtpClient(_settings.SmtpClient))
            {
                client.Setup(_settings);

                var mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress(_settings.Sender),
                };

                mailMessage.To.Add(email);

                mailMessage.BuildTemplate(message);

                client.Send(mailMessage);
            };
        }
    }
}
