using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Objects.Response
{
    public class Response
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("success")]
        public string success { get; set; }
    }
}
