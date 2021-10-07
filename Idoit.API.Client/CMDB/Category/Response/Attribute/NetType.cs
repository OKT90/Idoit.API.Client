﻿using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class NetType : Attribute
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("const")]
        public string _const { get; set; }
        [JsonProperty("title_lang")]
        public string titleLang { get; set; }
    }
}
