using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Dialog.Response
{
   public class Result
   {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("Const")]
        public string constant { get; set; }
        [JsonProperty("title")]
        public string title{ get; set; }
   }
}
