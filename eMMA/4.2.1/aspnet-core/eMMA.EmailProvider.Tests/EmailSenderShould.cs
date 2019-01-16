using Microsoft.Extensions.Options;
using Moq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace eMMA.EmailProvider.Tests
{
    public class EmailSenderShould
    {
        private IConfiguration Configuration { get; set; }

        public EmailSenderShould()
        {
            // the type specified here is just so the secrets library can 
            // find the UserSecretId we added in the csproj file
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<EmailSenderShould>();

            Configuration = builder.Build();
        }

            private Mock<EmailSenderWrapper> GetEmailSenderMock()
        {
            //IOptions<AuthMessageSenderOptions> optionsAccessor = new Options();
            var senderOptions = Options.Create(new AuthMessageSenderOptions()
            {
                SendGridUser = Configuration["SendGridUser"],
                SendGridKey = Configuration["SendGridKey"]
            });

            var clientMock = new Mock<SendGridClient>(null/*sendGridKey*/,null,null,null,null);

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
