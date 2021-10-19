using Newtonsoft.Json;


namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class DisabledLogin : Attribute
    {
        [JsonProperty("value")]
        public string value { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
    }
}
