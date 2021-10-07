using Idoit.API.Client.CMDB.Category.Response.Attribute;
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response
{
  public  class IP : IResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("objID")]
        public string objId { get; set; }
        [JsonProperty("primary_layer3_net")]
        public PrimaryLayer3Net primaryLayer3Net { get; set; }
        [JsonProperty("primary_hostaddress")]
        public PrimaryHostAddress primaryHostAddress { get; set; }
        [JsonProperty("primary_hostname")]
        public string primaryHostName { get; set; }
        [JsonProperty("net_type")]
        public NetType netType { get; set; }
        public Primary primary { get; set; }
        public Active active { get; set; }
        public Net net { get; set; }
        public string zone { get; set; }
        [JsonProperty("ipv4_assignment")]
        public IpV4Assignment iPV4Assignment { get; set; }
        [JsonProperty("ipv4_address")]
        public IPV4Address iPV4Address { get; set; }
        [JsonProperty("ipv6_assignment")]
        public IPV6Assignment iPV6Assignment { get; set; }
        [JsonProperty("ipv6_scope")]
        public IPV6Scope iPV6Scope { get; set; }
        [JsonProperty("ipv6_address")]
        public IPV6Address iPV6Address { get; set; }
        [JsonProperty("hostaddress")]
        public HostAddress hostAddress { get; set; }
        [JsonProperty("hostname")]
        public string hostName { get; set; }
        [JsonProperty("domain")]
        public string domain { get; set; }
        [JsonProperty("dns_server")]
        public string DNSServer { get; set; }
        [JsonProperty("dns_server_address")]
        public string DNSServerAddress { get; set; }
        [JsonProperty("dns_domain")]
        public DNSDomain[] DNSDomain { get; set; }
        [JsonProperty("use_standard_gateway")]
        public UseStandardGateway useStandardGateway { get; set; }
        [JsonProperty("assigned_port")]
        public string assignedPort { get; set; }
        [JsonProperty("assigned_logical_port")]
        public string assignedLogicalPort { get; set; }
        [JsonProperty("all_ips")]
        public string allIps { get; set; }
        [JsonProperty("primary_fqdn")]
        public PrimaryFqdn[] primaryFqdn { get; set; }
        [JsonProperty("aliases")]
        public Alias[] alias { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
