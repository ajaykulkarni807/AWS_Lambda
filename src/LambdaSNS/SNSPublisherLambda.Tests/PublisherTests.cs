using Amazon.Lambda.TestUtilities;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Moq;
using Xunit;

namespace SNSPublisherLambda.Tests
{
    public class PublisherTests
    {

        [Fact]
        public async void PublishMessageToSnsTopic()
        {
            // Arrange
            var snsMock = new Mock<IAmazonSimpleNotificationService>();
            snsMock.Setup(client => client.PublishAsync(It.IsAny<PublishRequest>(), default))
                .ReturnsAsync(new PublishResponse { MessageId = "123" });

            var function = new Function
            {
                _snsClient = snsMock.Object
            };

            // Act
            await function.FunctionHandler(new TestLambdaContext());

            // Assert
            snsMock.Verify(client => client.PublishAsync(It.IsAny<PublishRequest>(), default), Times.Once);
        }
    }
}
