using Amazon;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class AutoScalingDescribeNotificationConfigurationsOperation : Operation
    {
        public override string Name => "DescribeNotificationConfigurations";

        public override string Description => "Describes the notification actions associated with the specified Auto Scaling group.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AutoScaling";

        public override string ServiceID => "Auto Scaling";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAutoScalingClient client = new AmazonAutoScalingClient(creds, region);
            DescribeNotificationConfigurationsAnswer resp = new DescribeNotificationConfigurationsAnswer();
            do
            {
                DescribeNotificationConfigurationsType req = new DescribeNotificationConfigurationsType
                {
                    NextToken = resp.NextToken,
                    MaxRecords = maxItems
                };
                resp = client.DescribeNotificationConfigurations(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.NotificationConfigurations)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}