using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeAvailabilityZonesOperation : Operation
    {
        public override string Name => "DescribeAvailabilityZones";

        public override string Description => "Describes one or more of the Availability Zones that are available to you. The results include zones only for the region you&#39;re currently using. If there is an event impacting an Availability Zone, you can use this request to view the state and any provided message for that Availability Zone. For more information, see Regions and Availability Zones in the Amazon Elastic Compute Cloud User Guide.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Config config = new AmazonEC2Config();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonEC2Client client = new AmazonEC2Client(creds, config);
            
            DescribeAvailabilityZonesResponse resp = new DescribeAvailabilityZonesResponse();
            DescribeAvailabilityZonesRequest req = new DescribeAvailabilityZonesRequest
            {                    
                                    
            };
            resp = client.DescribeAvailabilityZones(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.AvailabilityZones)
            {
                AddObject(obj);
            }
            
        }
    }
}