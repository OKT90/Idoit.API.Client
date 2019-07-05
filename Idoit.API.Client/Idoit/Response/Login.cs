using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.Idoit.Response
{
    public class Login
    {
        [JsonProperty("result")]
        public bool result { get; set; }
        [JsonProperty("userid")]
        public string userId { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("mail")]
        public string mail { get; set; }
        [JsonProperty("username")]
        public string userName { get; set; }
        [JsonProperty("session-id")]
        public string sessionId { get; set; }
        [JsonProperty("client-id")]
        public string clientId { get; set; }
        [JsonProperty("client-name")]
        public string clientName { get; set; }
    }
}