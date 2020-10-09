using EmailSender.Utils;
using System;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace EmailSender.Extensions
{
    public static class EmailExtension
    {
        public static void BuildTemplate(this MailMessage mailMessage, string message)
        {
            var htmlString = GetHtmlString(message);
            var htmlView = AlternateView.CreateAlternateViewFromString(htmlString, null, "text/html");

            htmlView.AddImage(EmailImages.Logo, GetFullFileName(ImagePaths.Logo));

            mailMessage.AlternateViews.Add(htmlView);
        }

        private static string GetHtmlString(string message)
        {
            var builder = new StringBuilder();
            var templateFile = GetFullFileName(TemplatePaths.Email);

            using (var reader = File.OpenText(templateFile))
            {
                builder.Append(reader.ReadToEnd());
            }

            builder.Replace("{0}", message);

            return builder.ToString();
        }

        private static void AddImage(this AlternateView htmlView, string contentId, string fileName)
        {
            htmlView.LinkedResources.Add(new LinkedResource(fileName)
            {
                ContentId = contentId,
            });
        }

        private static string GetFullFileName(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }
    }

}
