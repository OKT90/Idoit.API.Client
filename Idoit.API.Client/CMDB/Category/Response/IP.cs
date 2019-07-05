using Idoit.API.Client.CMDB.Category.Response.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response
{
  public  class IP : IResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("objID")]
        public string objID { get; set; }
        public IPVAddress[] primary_hostaddress { get; set; }
        [JsonProperty("primary_hostname")]
        public string primaryHostname { get; set; }
        public DialogPlus net_type { get; set; }
        public Primary primary { get; set; }
        public Primary active { get; set; }
        public Net net { get; set; }
        public IPVAddress ipv4_address { get; set; }
        public DialogPlus ipv6_assignment { get; set; }
        public DialogPlus ipv6_scope { get; set; }
        public IPVAddress ipv6_address { get; set; }
        public IPVAddress hostaddress { get; set; }
        [JsonProperty("hostname")]
        public string hostname { get; set; }
        [JsonProperty("domain")]
        public string domain { get; set; }
        public string dns_server_address { get; set; }
        public Value use_standard_gateway { get; set; }
        [JsonProperty("all_ips")]
        public string allIps { get; set; }
        [JsonProperty("primary_fqdn")]
        public string primaryFqdn { get; set; }
        //public Alias[] aliases { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
