using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
  public class Alias
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("hostName")]
        public string hostname { get; set; }
        [JsonProperty("domain")]
        public string domain { get; set; }

    }
}
