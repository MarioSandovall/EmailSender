using EmailSender.Models;
using System.Net;
using System.Net.Mail;

namespace EmailSender.Extensions
{
    public static class SmtpExtension
    {
        public static void Setup(this SmtpClient client, EmailSettings settings)
        {
            client.EnableSsl = false;
            client.Port = settings.Port;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(settings.Sender, settings.Password); ;
        }
    }
}
