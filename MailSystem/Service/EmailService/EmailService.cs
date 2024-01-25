using MailKit.Net.Smtp;
using MailKit.Security;
using MailSystem.Model;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace MailSystem.Service.EmailService
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _config;
        public EmailService(IConfiguration _cofig)
        {
            _config = _cofig;  
        }
        public void sendMail(EmailDto request)
        {
            var email = new MimeMessage();

            //From
            email.From.Add(MailboxAddress.Parse(_config.GetSection("sendfromEmail").Value));

            //To
            email.To.Add(MailboxAddress.Parse(request.To.ToString()));

            //subject 
            email.Subject = request.Subject;

            //Body
            email.Body = new TextPart(TextFormat.Html) { Text = request.body };

            using var smtp = new SmtpClient();

            smtp.Connect(_config.GetSection("EmailHost").Value,587 , SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("sendfromEmail").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
            

        }
    }
}