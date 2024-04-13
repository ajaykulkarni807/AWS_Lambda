using Amazon.Lambda.Core;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SNSPublisherLambda;

public class Function
{
    internal IAmazonSimpleNotificationService _snsClient; 

    public Function()
    {
        // Specify the AWS region for the SNS client
        var snsConfig = new AmazonSimpleNotificationServiceConfig
        {
            RegionEndpoint = Amazon.RegionEndpoint.USEast1 
        };

        _snsClient = new AmazonSimpleNotificationServiceClient(snsConfig);
    }

    public async Task FunctionHandler(ILambdaContext context)
    {
        var topicArn = "your_topic_arn";
        var message = "Hello from SNS Publisher!";

        var request = new PublishRequest
        {
            TopicArn = topicArn,
            Message = message
        };

        await _snsClient.PublishAsync(request);
    }
}
