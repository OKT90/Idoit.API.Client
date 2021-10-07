using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class UseStandardGateway : Attribute
    {
        [JsonProperty("value")]
        public int value { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
    }
}
