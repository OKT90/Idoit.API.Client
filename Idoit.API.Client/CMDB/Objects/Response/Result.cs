using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Objects.Response
{
   public class Result
   {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("sysid")]
        public string sysId { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("created")]
        public string created { get; set; }
        [JsonProperty("updated")]
        public string updated { get; set; }
        [JsonProperty("type_title")]
        public string typeTitle { get; set; }
        [JsonProperty("typeGroupTitle")]
        public string type_group_title { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("cmdb_status")]
        public string cmdbStatus { get; set; }
        [JsonProperty("cmdbStatusTitle")]
        public string cmdb_status_title { get; set; }
        [JsonProperty("image")]
        public string image { get; set; }
   }
}
