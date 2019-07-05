using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Request
{
   public class IP : IRequest
    {
        public int category_id { get; set; }
        public string primary_hostaddress { get; set; }
        public string primary_hostname { get; set; }
        public int net_type { get; set; }
        public int primary { get; set; }
        public int active { get; set; }
        public int net { get; set; }
        public int zone { get; set; }
        public int ipv4_assignment { get; set; }
        public string ipv4_address { get; set; }
        public int ipv6_assignment { get; set; }
        public int ipv6_scope { get; set; }
        public string ipv6_address { get; set; }
        public string hostaddress { get; set; }
        public string hostname { get; set; }
        public string domain { get; set; }
        public int dns_server { get; set; }
        public string dns_server_address { get; set; }
        public int search_domain { get; set; }
        public int use_standard_gateway { get; set; }
        public int assigned_logical_port { get; set; }
        public string all_ips { get; set; }
        public string primary_fqdn { get; set; }
        public string aliases { get; set; }
        public string description { get; set; }
        

    }
}
