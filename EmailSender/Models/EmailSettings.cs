namespace EmailSender.Models
{
    public class EmailSettings
    {
        public string SmtpClient { get; set; }

        public string Sender { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

    }
}
