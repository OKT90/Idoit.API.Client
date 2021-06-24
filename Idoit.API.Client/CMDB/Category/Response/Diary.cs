using Idoit.API.Client.CMDB.Category.Response.Attribute;
using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Response
{
    public class Diary : IResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("objID")]
        public string objID { get; set; }
        [JsonProperty("f_popup_c_1581927717973")]
        public Date date { get; set; }
        [JsonProperty("f_popup_c_1581927723207")]
        public AssignedContact author { get; set; }
        [JsonProperty("f_wysiwyg_c_1581927732804")]
        public string entry { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
