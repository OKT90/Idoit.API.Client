using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class PrimaryHostAddress : Attribute
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("sysid")]
        public string sysId { get; set; }
        [JsonProperty("ref_id")]
        public string refId { get; set; }
        [JsonProperty("ref_title")]
        public string refTitle { get; set; }
        [JsonProperty("ref_type")]
        public string refType { get; set; }
    }
}
