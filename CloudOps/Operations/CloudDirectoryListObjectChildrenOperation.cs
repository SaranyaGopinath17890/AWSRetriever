using Amazon;
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudDirectoryListObjectChildrenOperation : Operation
    {
        public override string Name => "ListObjectChildren";

        public override string Description => "Returns a paginated list of child objects that are associated with a given object.";
 
        public override string RequestURI => "/amazonclouddirectory/2017-01-11/object/children";

        public override string Method => "POST";

        public override string ServiceName => "CloudDirectory";

        public override string ServiceID => "CloudDirectory";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudDirectoryClient client = new AmazonCloudDirectoryClient(creds, region);
            ListObjectChildrenResponse resp = new ListObjectChildrenResponse();
            do
            {
                ListObjectChildrenRequest req = new ListObjectChildrenRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListObjectChildren(req);
                CheckError(resp.HttpStatusCode, "200");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}