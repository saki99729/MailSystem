using MailSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace MailSystem.Service.EmailService
{
    public interface IEmailService
    {
        void sendMail(EmailDto request);
    }
}
