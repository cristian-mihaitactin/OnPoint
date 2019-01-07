using Microsoft.Extensions.Options;
using Moq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace eMMA.EmailProvider.Tests
{
    public class EmailSenderShould
    {
        private readonly string sendGridKey = @"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";

        private Mock<EmailSenderWrapper> GetEmailSenderMock()
        {
            //IOptions<AuthMessageSenderOptions> optionsAccessor = new Options();
            var senderOptions = Options.Create(new AuthMessageSenderOptions()
            {
                SendGridUser = sendGridUser,
                SendGridKey = sendGridKey
            });

            var clientMock = new Mock<SendGridClient>(sendGridKey,null,null,null,null);

            var emailSenderWrapper = new Mock<EmailSenderWrapper>(senderOptions, clientMock);

            return emailSenderWrapper;
        }
        [Fact]
        public async void CallSendEmailHavingValidInfo()
        {
            //Arrange
            var sender = GetEmailSenderMock();
            sender.Setup(arg => arg.SendEmailAsync(It.IsAny<SendGridMessage>(), It.IsAny<SendGridClient>()))
                                .Returns(Task.CompletedTask);

            var email = "test@abc.com";
            var subject = "Test test";
            var message = "This is a test! ;)";

            //Act
            await sender.Object.SendEmailAsync(email, subject, message);

            //Assert
            sender.Verify(send => send.SendEmailAsync(It.IsAny<SendGridMessage>(),It.IsAny<SendGridClient>()), Times.Once());
        }
    }

    public class EmailSenderWrapper : EmailSender
    {
        private Mock<SendGridClient> client;

        public Mock<SendGridClient> Client => client;

        public EmailSenderWrapper(IOptions<AuthMessageSenderOptions> optionsAccessor, Mock<SendGridClient> emailClient) : base(optionsAccessor)
        {
            client = emailClient;
        }

        protected override SendGridClient CreateSendGridClient(string apiKey)
        {
            return client.Object;
        }
    }
}
