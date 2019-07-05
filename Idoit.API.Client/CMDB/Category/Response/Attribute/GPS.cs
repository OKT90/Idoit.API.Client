using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
  public  class GPS
    {
        [JsonProperty("zero")]
        public string zero { get; set; }
        [JsonProperty("one")]
        public string one { get; set; }
        [JsonProperty("latitude")]
        public string latitude { get; set; }
        [JsonProperty("longitude")]
        public string longitude { get; set; }

    }
}
