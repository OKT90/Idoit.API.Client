using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class Parent : Attribute
    {
        [JsonProperty("sysid")]
        public string sysId { get; set; }
        [JsonProperty("type_title")]
        public string typeTitle { get; set; }
        [JsonProperty("location_path")]
        public string locationPath { get; set; }
    }
}
