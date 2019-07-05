using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class ContactObject : Attribute
    {
        [JsonProperty("connection_id")]
        public string connectionId { get; set; }
        [JsonProperty("type_title")]
        public string typeTitle { get; set; }
        [JsonProperty("sysid")]
        public string sysId { get; set; }
    
    }
}
