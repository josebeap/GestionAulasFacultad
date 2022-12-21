using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Logica.Services
{
    public class Notifications
    {
        public Boolean SendEmail(string subject, string content, string toName, string toEmail)
        {
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("jose.1701710903@ucaldas.edu.co", "Jose L Beltran A");

            var to = new EmailAddress(toEmail, toName);
            var plainTextContent = content;
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
            return true;
        }

        public Boolean SendSMS(string content, string to, string from)
        {
            // twillio service
            return true;
        }
    }
}
