using DotnetELK.Handler;
using MailKit.Net.Smtp;
using MailKit.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System.Net;

namespace DotnetELK.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> NotifyTeamsViaMail() {
            var messageReceivedFromUserNotification = new MessageReceivedFromUserNotification
            {
                EmailAddress = "EmailAddress",
                FullName = ".FullName",
                Message = "contactUs.Message",
                SubmittedAt = DateTime.UtcNow
            };
            await _mediator.Publish(messageReceivedFromUserNotification);
            return Ok();
        }


        [HttpGet(Name = "Notify")]
        public async Task<IActionResult> NotifyTeams()
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Joey Tribbiani", "campaignplanningtool@gmail.com"));
                message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "zeynepyaliniz7@gmail.com"));
                message.Subject = "How you doin'?";

                message.Body = new TextPart("plain")
                {
                    Text = @"Hey Chandler,I just wanted to let you know that Monica and I were going to go play some paintball, you in?-- Joey"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587);


                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // Note: only needed if the SMTP server requires authentication
                   await client.AuthenticateAsync("my-gmail@gmail.com", "dyukomlrbenwvrff");

                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
            }

            catch (Exception ex)
            {
                throw new BadHttpRequestException(ex.Message.ToString());
            }

                       

            return Ok("mail send!!");
        }
    }
}
