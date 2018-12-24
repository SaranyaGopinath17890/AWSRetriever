using Amazon;
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class StorageGatewayListLocalDisksOperation : Operation
    {
        public override string Name => "ListLocalDisks";

        public override string Description => "Returns a list of the gateway&#39;s local disks. To specify which gateway to describe, you use the Amazon Resource Name (ARN) of the gateway in the body of the request. The request returns a list of all disks, specifying which are configured as working storage, cache storage, or stored volume or not configured at all. The response includes a DiskStatus field. This field can have a value of present (the disk is available to use), missing (the disk is no longer connected to the gateway), or mismatch (the disk node is occupied by a disk that has incorrect metadata or the disk content is corrupted).";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "StorageGateway";

        public override string ServiceID => "Storage Gateway";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonStorageGatewayClient client = new AmazonStorageGatewayClient(creds, region);
            ListLocalDisksOutput resp = new ListLocalDisksOutput();
            do
            {
                ListLocalDisksInput req = new ListLocalDisksInput
                {
                    &lt;nil&gt; = resp.&lt;nil&gt;,
                    &lt;nil&gt; = maxItems
                };
                resp = client.ListLocalDisks(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.Disks)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.&lt;nil&gt;));
        }
    }
}