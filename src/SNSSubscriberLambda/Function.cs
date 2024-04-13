using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SNSSubscriberLambda;
public class Function
{
    internal IAmazonSimpleNotificationService _snsClient;

    public Function(IAmazonSimpleNotificationService snsClient)
    {
        _snsClient = snsClient;
    }

    public async Task FunctionHandler(SNSEvent snsEvent, ILambdaContext context)
    {
        foreach (var record in snsEvent.Records)
        {
            var message = record.Sns.Message;

            // Process the message here

            // Confirm the subscription after processing the message
            var confirmRequest = new ConfirmSubscriptionRequest
            {
                TopicArn = record.Sns.TopicArn,
                Token = "dummy_token" // Replace with the actual token from the SNS message
            };

            await _snsClient.ConfirmSubscriptionAsync(confirmRequest);
        }
    }
}