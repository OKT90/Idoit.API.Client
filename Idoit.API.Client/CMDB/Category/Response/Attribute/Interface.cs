using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
   public class Interface : Attribute
    {
        [JsonProperty("serial")]
        public string serial { get; set; }
        [JsonProperty("slot")]
        public string slot { get; set; }
        [JsonProperty("manufacturer")]
        public string manufacturer { get; set; }
        [JsonProperty("model")]
        public string model { get; set; }
 
    }
}
