using Bytes2you.Validation;
using SchoolSystem.Web.Services.Contracts;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SchoolSystem.Web.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private const string hostEmail = "hlebforms@gmail.com";
        private const string hostEmailPassword = "hlebforms1234";
        private const int port = 587;
        private const string host = "smtp.gmail.com";
        private const string subject = "Акаунт за училищната система";
        private SmtpClient client;

        public EmailSenderService(SmtpClient client)
        {
            Guard.WhenArgument(client, "SmtpClient").IsNull().Throw();
            this.Client = client;
        }

        private SmtpClient Client
        {
            get
            {
                return this.client;
            }
            set
            {
                this.client = value;
                this.client.Port = port;
                this.client.Host = host;
                this.client.EnableSsl = true;
                this.client.Timeout = 10000;
                this.client.DeliveryMethod = SmtpDeliveryMethod.Network;
                this.client.UseDefaultCredentials = false;
                this.client.Credentials = new NetworkCredential(hostEmail, hostEmailPassword);
            }
        }

        public void SendEmail(string receiver, string password)
        {
            var content = new StringBuilder();
            content.Append("Здравейте, <br /><br />");
            content.Append("Вече имате регистрация в училищната система. <br />");
            content.Append("Вашият акаунт за достъп е : <b>" + receiver + "</b> <br />");
            content.Append("Вашата парола е : <b>" + password + "</b> <br /><br />");
            content.Append("За по-голяма сигурност, може влезте в системата и сменете паролата си!");

            MailMessage mailMessage = new MailMessage(hostEmail, receiver, subject, content.ToString());
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            this.Client.Send(mailMessage);
        }
    }
}
