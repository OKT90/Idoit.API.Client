using Idoit.API.Client.CMDB.Category.Response.Attribute;
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response
{
    public class PersonsLogin : IResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("objID")]
        public string objID { get; set; }
        [JsonProperty("disabled_login")]
        public DisabledLogin disabledLogin { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("user_pass")]
        public string user_pass { get; set; }
        [JsonProperty("user_pass2")]
        public string user_pass2 { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
