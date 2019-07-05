using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Anemonis.JsonRpc.ServiceClient;
using Newtonsoft.Json;
namespace Idoit.API.Client.CMDB.Category.Request
{
    public class Cpu : IRequest
    {
        public int category_id { get; set; }// This Attribut is jsut for the Multi-value category
        public string title { get; set; }
        public int manufacturer { get; set; }
        public int type { get; set; }
        public double frequency { get; set; }
        public int frequencyUnit { get; set; }
        public int cores { get; set; }
        public string description { get; set; }
      

    }
}
