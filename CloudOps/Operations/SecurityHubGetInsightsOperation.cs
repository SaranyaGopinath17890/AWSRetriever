using Amazon;
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SecurityHubGetInsightsOperation : Operation
    {
        public override string Name => "GetInsights";

        public override string Description => "Lists and describes insights that are specified by insight ARNs.";
 
        public override string RequestURI => "/insights/get";

        public override string Method => "POST";

        public override string ServiceName => "SecurityHub";

        public override string ServiceID => "SecurityHub";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSecurityHubClient client = new AmazonSecurityHubClient(creds, region);
            GetInsightsResponse resp = new GetInsightsResponse();
            do
            {
                GetInsightsRequest req = new GetInsightsRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.GetInsights(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}