using MailKit.Net.Smtp;
using MailKit.Security;
using MailSystem.Model;
using MailSystem.Service.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace MailSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailSMTPController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public MailSMTPController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.sendMail(request);

            return Ok("send email :" + request);

        }
    }
}

