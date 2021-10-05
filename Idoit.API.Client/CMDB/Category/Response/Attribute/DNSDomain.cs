using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class DNSDomain : Attribute
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
    }
}
