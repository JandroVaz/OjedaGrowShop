using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace OjedaGrowShop.Helper
{
    public class MailServices
    {

        private readonly IConfiguration configuration;

        public MailServices(IConfiguration configuration)
        {
            this.configuration = configuration; 
        }

        public void SendEmailOutlook(string receptor, string mensaje = "", string asunto = "Mensaje")
        {
            MailMessage mail = new MailMessage();

            string userMail = configuration["usuariooutlook"];
            string passwordmail = configuration["passwordoutlook"];

            mail.From = new MailAddress(userMail);
            mail.To.Add(new MailAddress(receptor));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            string smtpserver = configuration["host"];
            int port = int.Parse(configuration["port"]);
            bool ssl = bool.Parse(configuration["ssl"]);
            bool defaultcredentials = bool.Parse(configuration["defaultcredentials"]);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = smtpserver,
                Port = port,
                EnableSsl = ssl,
                UseDefaultCredentials = defaultcredentials
            };

            NetworkCredential userCredential = new NetworkCredential(userMail, passwordmail);

            smtpClient.Credentials = userCredential;
            smtpClient.Send(mail);

            smtpClient.Dispose();

        }

    }
}
