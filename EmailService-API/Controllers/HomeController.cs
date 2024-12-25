using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace EmailService_API.Controllers;

[ApiController]
[Tags("home-controller")]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpPost("EmailSendWithHTML")]
    public async Task<IActionResult> EmailSendWithHTML(string email, string subject, string content)
    {
        try
        {
            var smtpClient = new SmtpClient("smtp.mail.ru", 587)
            {
                Credentials = new NetworkCredential("asifrjv@mail.ru", "KPvEgW2YrMHK9Bfsuy6r"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("asifrjv@mail.ru"),
                Subject = subject,
                Body = content,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);

            return Ok("Email successfully sent!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while sending email: {ex.Message}");
        }
    }
}