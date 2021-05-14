using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class Date
    {
        [JsonProperty("title")]
        public string date { get; set; }
        [JsonProperty("prop_type")]
        public string type { get; set; }
    }
}
