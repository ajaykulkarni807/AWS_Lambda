****AWS Lambda SNS Publisher and Subscriber with Unit Tests****

This repository contains two AWS Lambda functions: SNSPublisherLambda and SNSSubscriberLambda, along with their respective unit test projects: SNSPublisherUnitTest and SNSSubscriberUnitTest.

**Overview**
SNSPublisherLambda: A Lambda function responsible for publishing messages to an SNS topic.
SNSSubscriberLambda: A Lambda function responsible for subscribing to an SNS topic and processing incoming messages.
SNSPublisherUnitTest: Unit tests for the SNSPublisherLambda function.
SNSSubscriberUnitTest: Unit tests for the SNSSubscriberLambda function.

**Prerequisites**
.NET SDK
AWS CLI configured with necessary permissions
AWS Toolkit for Visual Studio (optional)
**Setup**
1. Clone the Repository
Clone this repository to your local machine:
git clone https://github.com/ajaykulkarni807/AWS_Lambda.git
2. Open Solution in Visual Studio
Navigate to the cloned repository and open the LambdaSNS.sln solution file in Visual Studio 2022.

3. Restore NuGet Packages
Restore the NuGet packages for all projects to ensure all dependencies are downloaded and installed.

4. Configuration
Update the AWS region and other configurations in the Lambda function code if necessary. By default, the region is set to USEast1.

**Projects**
SNSPublisherLambda
This project contains the Lambda function for publishing messages to an SNS topic.

Function: FunctionHandler - Publishes a message to the specified SNS topic.
SNSSubscriberLambda
This project contains the Lambda function for subscribing to an SNS topic and processing incoming messages.

Function: FunctionHandler - Processes incoming SNS messages and confirms the subscription.
SNSPublisherUnitTest
This project contains unit tests for the SNSPublisherLambda function.

PublisherTests: Tests the publishing functionality of SNSPublisherLambda.
SNSSubscriberUnitTest
This project contains unit tests for the SNSSubscriberLambda function.

SubscriberTests: Tests the subscribing and message processing functionality of SNSSubscriberLambda.
Running Unit Tests
To run the unit tests:

Open Test Explorer in Visual Studio (Test -> Test Explorer).
Build the solution (Build -> Build Solution).
Run all tests from Test Explorer (Run All button).
Deploying to AWS
You can deploy these Lambda functions using the AWS CLI, AWS Toolkit for Visual Studio, or any other preferred deployment method.

**Package the Lambda Functions:**

dotnet lambda package --configuration Release --framework netcoreapp3.1 --output-package bin/Release/netcoreapp3.1/SNSPublisherLambda.zip --msbuild-parameters /p:PublishReadyToRun=true
dotnet lambda package --configuration Release --framework netcoreapp3.1 --output-package bin/Release/netcoreapp3.1/SNSSubscriberLambda.zip --msbuild-parameters /p:PublishReadyToRun=true

**Deploy to AWS:**


aws lambda update-function-code --function-name SNSPublisherLambda --zip-file fileb://bin/Release/netcoreapp3.1/SNSPublisherLambda.zip
aws lambda update-function-code --function-name SNSSubscriberLambda --zip-file fileb:
