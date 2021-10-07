using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class Net : Attribute
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("sysid")]
        public string sysId { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("type_title")]
        public string typeTitle { get; set; }
    }
}
