using Idoit.API.Client.CMDB.Category.Response.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Response
{
   public class Location:IResponse
   {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("objID")]
        public string objID { get; set; }
        [JsonProperty("location_path")]
        public string locationPath { get; set; }
        public Parent parent { get; set; }
        [JsonProperty("option")]
        public string option { get; set; }
        [JsonProperty("insertion")]
        public string insertion { get; set; }
        public GPS gps { get; set; }
        [JsonProperty("latitude")]
        public string latitude { get; set; }
        [JsonProperty("longitude")]
        public string longitude { get; set; }
        [JsonProperty("snmpSyslocation")]
        public string snmp_syslocation { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
   }
}
