using System;
using System.Collections.Generic;
using System.Text;
using Idoit.API.Client.CMDB.Category.Response.Attribute;
using System.Threading.Tasks;
using Anemonis.JsonRpc.ServiceClient;
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response
{
    public class Cpu : IResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("objID")]
        public string objID { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        public DialogPlus manufacturer { get; set; }
        public DialogPlus type { get; set; }
        //public Unit frequency { get; set; }
        public DialogPlus frequency_unit { get; set; }
        [JsonProperty("cores")]
        public string cores { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }


    }
}

