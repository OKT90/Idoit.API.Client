using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
   public class Cable : Attribute
    {
        [JsonProperty("cable_id")]
        public string cableId { get; set; }
        [JsonProperty("sysid")]
        public string sysId { get; set; }
 
    }
}
