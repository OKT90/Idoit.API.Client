using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class Frequency : Attribute
    {
        [JsonProperty("sysid")]
        public string sysId { get; set; }
     
    }
}
