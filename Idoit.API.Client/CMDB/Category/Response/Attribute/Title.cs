using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class Title
    {
        [JsonProperty("title")]
        public string title { get; set; }
    }
}
