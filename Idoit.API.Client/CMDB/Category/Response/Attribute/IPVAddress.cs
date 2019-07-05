using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
  public  class IPVAddress : Attribute
    {
        [JsonProperty("sysid")]
        public string sysId { get; set; }
        [JsonProperty("ref_id")]
        public string refId { get; set; }
        [JsonProperty("ref_title")]
        public string refTitle { get; set; }
        [JsonProperty("ref_type")]
        public string refType { get; set; }
    }
}
