using Idoit.API.Client.CMDB.Category.Response.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response
{
   public class Formfactor : IResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("objID")]
        public string objID { get; set; }
        public DialogPlus formfactor { get; set; }
        [JsonProperty("rackunits")]
        public string rackUnits { get; set; }
        public DialogPlus unit { get; set; }
        public Title width { get; set; }
        public Title height { get; set; }
        public Title depth { get; set; }
        public Title weight { get; set; }
        public DialogPlus weight_unit { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
