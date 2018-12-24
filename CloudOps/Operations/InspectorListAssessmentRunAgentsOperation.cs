using Amazon;
using Amazon.Inspector;
using Amazon.Inspector.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class InspectorListAssessmentRunAgentsOperation : Operation
    {
        public override string Name => "ListAssessmentRunAgents";

        public override string Description => "Lists the agents of the assessment runs that are specified by the ARNs of the assessment runs.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "Inspector";

        public override string ServiceID => "Inspector";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonInspectorClient client = new AmazonInspectorClient(creds, region);
            ListAssessmentRunAgentsResponse resp = new ListAssessmentRunAgentsResponse();
            do
            {
                ListAssessmentRunAgentsRequest req = new ListAssessmentRunAgentsRequest
                {
                    nextToken = resp.nextToken,
                    maxResults = maxItems
                };
                resp = client.ListAssessmentRunAgents(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.nextToken));
        }
    }
}