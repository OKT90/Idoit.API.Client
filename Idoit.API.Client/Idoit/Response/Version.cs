using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Anemonis.JsonRpc;
using Newtonsoft.Json;

namespace Idoit.API.Client.Idoit.Response
{
    public class Version
    {
        public VersionLogin login { get; set; }
        [JsonProperty("version")]
        public string version { get; set; }
        [JsonProperty("step")]
        public string step { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
    }
}
 