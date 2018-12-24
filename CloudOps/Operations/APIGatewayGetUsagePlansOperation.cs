using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetUsagePlansOperation : Operation
    {
        public override string Name => "GetUsagePlans";

        public override string Description => "Gets all the usage plans of the caller&#39;s account.";
 
        public override string RequestURI => "/usageplans";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            UsagePlans resp = new UsagePlans();
            do
            {
                GetUsagePlansRequest req = new GetUsagePlansRequest
                {
                    position = resp.position,
                    limit = maxItems
                };
                resp = client.GetUsagePlans(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.items)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.position));
        }
    }
}