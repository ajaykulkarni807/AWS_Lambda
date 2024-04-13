using Amazon.Lambda.SNSEvents;
using Amazon.Lambda.TestUtilities;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Moq;
using Xunit;

namespace SNSSubscriberLambda.Tests
{
    public class SubscriberTests
    {
        public class FunctionTests
        {
            [Fact]
            public async Task FunctionHandler_ShouldConfirmSubscription()
            {
                // Arrange
                var mockSnsClient = new Mock<IAmazonSimpleNotificationService>();
                mockSnsClient.Setup(client => client.ConfirmSubscriptionAsync(It.IsAny<ConfirmSubscriptionRequest>(), default))
                              .ReturnsAsync(new ConfirmSubscriptionResponse { SubscriptionArn = "test_subscription_arn" });

                var function = new Function(mockSnsClient.Object);

                var snsMessage = new SNSEvent.SNSMessage
                {
                    Message = "Test message",
                    TopicArn = "arn:aws:sns:region:account-id:topic-name"
                };

                var snsRecord = new SNSEvent.SNSRecord
                {
                    EventSource = "aws:sns",
                    EventSubscriptionArn = "arn:aws:sns:region:account-id:subscription-name:subscription-id",
                    EventVersion = "1.0",
                    Sns = snsMessage
                };

                var snsEvent = new SNSEvent
                {
                    Records = new List<SNSEvent.SNSRecord> { snsRecord }
                };

                // Act
                await function.FunctionHandler(snsEvent, new TestLambdaContext());

                // Assert
                mockSnsClient.Verify(client => client.ConfirmSubscriptionAsync(It.IsAny<ConfirmSubscriptionRequest>(), default), Times.Once);
            }
        }
    }

}