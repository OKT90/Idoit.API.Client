using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.ObjectTypes.Response
{
    public class Result
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("container")]
        public string container { get; set; }
        [JsonProperty("Const")]
        public string Const { get; set; }
        [JsonProperty("color")]
        public string color { get; set; }
        [JsonProperty("image")]
        public string image { get; set; }
        [JsonProperty("icon")]
        public string icon { get; set; }
        [JsonProperty("cats")]
        public string cats { get; set; }
        [JsonProperty("tree_group")]
        public string treeGroup { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("typeGroup")]
        public string type_group { get; set; }
        [JsonProperty("type_group_title")]
        public string typeGroupTitle { get; set; }
    }
}
