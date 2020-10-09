using EmailSender.Models;
using EmailSender.Services;
using System;

namespace EmailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailService = CreateEmailService();

            const string email = "mario_sandovall@outlook.com";
            const string message = "This is an email example";

            emailService.Send(email, message);

            Console.ReadLine();
        }

        private static EmailService CreateEmailService()
        {
            var settings = new EmailSettings
            {
                Port = 8889,
                Password = "Password",
                SmtpClient = "SmtpClient",
                Sender = "Sender"
            };

            return new EmailService(settings);
        }
    }
}
