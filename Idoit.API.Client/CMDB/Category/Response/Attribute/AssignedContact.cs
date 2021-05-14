using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class AssignedContact : Attribute
    {
        [JsonProperty("sysid")]
        public string sysID { get; set; }
        [JsonProperty("type_title")]
        public string typeTitle { get; set; }
        [JsonProperty("prop_type")]
        public string propType { get; set; }
        [JsonProperty("identifier")]
        public string identifier { get; set; }
    }
}
