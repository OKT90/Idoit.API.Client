﻿using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
   public class Primary
    {
        [JsonProperty("value")]
        public string value { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
    }
}
