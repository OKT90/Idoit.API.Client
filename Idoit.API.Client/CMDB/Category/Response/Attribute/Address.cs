using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response.Attribute
{
    public class Address : Attribute
    {
        [JsonProperty("hostname")]
        public string hostName { get; set; }
    }
}
