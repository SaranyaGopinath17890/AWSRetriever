using Amazon;
using Amazon.ResourceGroups;
using Amazon.ResourceGroups.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ResourceGroupsSearchResourcesOperation : Operation
    {
        public override string Name => "SearchResources";

        public override string Description => "Returns a list of AWS resource identifiers that matches a specified query. The query uses the same format as a resource query in a CreateGroup or UpdateGroupQuery operation.";
 
        public override string RequestURI => "/resources/search";

        public override string Method => "POST";

        public override string ServiceName => "ResourceGroups";

        public override string ServiceID => "Resource Groups";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonResourceGroupsClient client = new AmazonResourceGroupsClient(creds, region);
            SearchResourcesOutput resp = new SearchResourcesOutput();
            do
            {
                SearchResourcesInput req = new SearchResourcesInput
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.SearchResources(req);
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