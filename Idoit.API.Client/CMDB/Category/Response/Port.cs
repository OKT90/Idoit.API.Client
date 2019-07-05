using Idoit.API.Client.CMDB.Category.Response.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response
{
    public class Port : IResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("objID")]
        public string objID { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        public Interface[] Interface { get; set; }
        public DialogPlus port_type { get; set; }
        public DialogPlus port_mode { get; set; }
        public DialogPlus plug_type { get; set; }
        public DialogPlus negotiation { get; set; }
        public DialogPlus duplex { get; set; }
        public Title speed { get; set; }
        public DialogPlus speed_type { get; set; }
        public DialogPlus standard { get; set; }
        [JsonProperty("mac")]
        public string mac { get; set; }
        [JsonProperty("mtu")]
        public string mtu { get; set; }
        public Assigned[] assigned_connector { get; set; }
        [JsonProperty("connector")]
        public string connector { get; set; }
        public Cable[] cable { get; set; }
        public Primary active { get; set; }
        public Address[] addresses { get; set; }
        public Frequency[] layer2_assignment { get; set; }
        [JsonProperty("default_vlan")]
        public string defaultVlan { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("relation_direction")]
        public string relationDirection { get; set; }
    }
}
