using Idoit.API.Client.CMDB.Category.Response.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response
{
  public  class Memory : IResponse
  {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("objID")]
        public int objID { get; set; }
        [JsonProperty("quantity")]
        public string quantity { get; set; }
        public DialogPlus title { get; set; }
        public DialogPlus manufacturer { get; set; }
        public DialogPlus type { get; set; }
        [JsonProperty("total_capacity")]
        public string totalCapacity { get; set; }
        public Title capacity { get; set; }
        public DialogPlus unit { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
  }
}
