using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace Idoit.API.Client.Idoit.Response
{
    public class Logout
    {
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("result")]
        public bool result{ get; set; }
    }
}
 