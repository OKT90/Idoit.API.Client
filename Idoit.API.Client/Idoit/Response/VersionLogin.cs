using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.Idoit.Response
{
    public class VersionLogin
    {
        [JsonProperty("userid")]
        public string userId { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("mail")]
        public string mail { get; set; }
        [JsonProperty("username")]
        public string userName { get; set; }
        [JsonProperty("mandator")]
        public string mandator { get; set; }
        [JsonProperty("language")]
        public string language { get; set; }
    }
}
