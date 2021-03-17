using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
   public class DialogPlus
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("const")]
        public string constant { get; set; }
        [JsonProperty("title_lang")]
        public string titleLang { get; set; }
    }
}
