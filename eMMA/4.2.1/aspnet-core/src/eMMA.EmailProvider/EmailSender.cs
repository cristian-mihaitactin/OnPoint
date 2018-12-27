﻿using eMMA.Interfaces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace eMMA.EmailProvider
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = CreateSendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("admin@eMMA.com", "eMMA Admin"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return SendEmailAsync(msg, client);
        }

        public virtual Task SendEmailAsync(SendGridMessage msg, SendGridClient client)
        {
            return client.SendEmailAsync(msg);
        }

        //protected to be mocked in tests
        protected virtual SendGridClient CreateSendGridClient(string apiKey)
        {
            return new SendGridClient(apiKey);
        }
    }
}
