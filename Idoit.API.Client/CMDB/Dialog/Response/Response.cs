using Anemonis.JsonRpc.ServiceClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Dialog.Response
{
    public class Response
    {
        [JsonProperty("entry_id")]
        public int entryId { get; set; }
        [JsonProperty("success")]
        public string success { get; set; }
    }
}
