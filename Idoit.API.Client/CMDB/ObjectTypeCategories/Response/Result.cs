using Newtonsoft.Json;
using System.Collections.Generic;

namespace Idoit.API.Client.CMDB.ObjectTypeCategories.Response
{
    public class Result
    {
        [JsonProperty("catg")]
        public List<catgs> catg { get; set; }
        [JsonProperty("Custom")]
        public List<Customs> Custom { get; set; }
    }
    public class Customs
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("const")]
        public string consts { get; set; }
        [JsonProperty("parent")]
        public string parent { get; set; }
        [JsonProperty("multi_value")]
        public string multi_value { get; set; }
        [JsonProperty("source_table")]
        public string source_table { get; set; }
    }
    public class catgs
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("const")]
        public string consts { get; set; }
        [JsonProperty("parent")]
        public string parent { get; set; }
        [JsonProperty("multi_value")]
        public string multi_value { get; set; }
        [JsonProperty("source_table")]
        public string source_table { get; set; }

    }
}
