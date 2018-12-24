using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeCacheSubnetGroupsOperation : Operation
    {
        public override string Name => "DescribeCacheSubnetGroups";

        public override string Description => "Returns a list of cache subnet group descriptions. If a subnet group name is specified, the list contains only the description of that group.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            CacheSubnetGroupMessage resp = new CacheSubnetGroupMessage();
            do
            {
                DescribeCacheSubnetGroupsMessage req = new DescribeCacheSubnetGroupsMessage
                {
                    Marker = resp.Marker,
                    MaxRecords = maxItems
                };
                resp = client.DescribeCacheSubnetGroups(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.CacheSubnetGroups)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}