using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class APIGatewayGetDeploymentsOperation : Operation
    {
        public override string Name => "GetDeployments";

        public override string Description => "Gets information about a Deployments collection.";
 
        public override string RequestURI => "/restapis/{restapi_id}/deployments";

        public override string Method => "GET";

        public override string ServiceName => "APIGateway";

        public override string ServiceID => "API Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAPIGatewayClient client = new AmazonAPIGatewayClient(creds, region);
            Deployments resp = new Deployments();
            do
            {
                GetDeploymentsRequest req = new GetDeploymentsRequest
                {
                    position = resp.position,
                    limit = maxItems
                };
                resp = client.GetDeployments(req);
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