using System;
using System.Collections.Generic;
using System.Text;


namespace Idoit.API.Client.CMDB.Category.Request
{
    public class Port : IRequest
    {
        public int category_id { get; set; }// This Attribut is jsut for the Multivalue Category
        public string title { get; set; }
        public int Interface { get; set; }  
        public int port_type { get; set; }
        public int port_mode { get; set; }
        public int plug_type { get; set; }
        public int negotiation { get; set; }
        public int duplex { get; set; }
        public float speed { get; set; }
        public int speed_type { get; set; }
        public int standard { get; set; }
        public string mac { get; set; }
        public string mtu { get; set; }
        public int assigned_connector { get; set; }
        public int connector { get; set; }
        public int connector_sibling { get; set; }
        public int cable { get; set; }
        public int active { get; set; }
        public int addresses { get; set; }
        public int layer2_assignment { get; set; }
        public int hba { get; set; }
        public int default_vlan { get; set; }
        public string description { get; set; }
        public int relation_direction { get; set; }
    }
}
