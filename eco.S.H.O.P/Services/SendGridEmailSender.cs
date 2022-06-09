using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eco.S.H.O.P.Services
{
    internal class SendGridEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
       // private readonly ILogger _logger;
        public SendGridEmailSender(IConfiguration configuration) //,ILogger logger)
        {
            _configuration = configuration;
            //_logger = logger;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _configuration["SendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress("test.itstepacademy@gmail.com", "TEST SendGrid"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            message.AddTo(email);

            var response = await client.SendEmailAsync(message);

            //if (response.IsSuccessStatusCode)
            //    _logger.LogInformation("Email Send");
            //else
            //    _logger.LogInformation("ERRRROR");
        }
    }
}
