using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Request
{
  public class Access : IRequest
    {
        public int category_id { get; set; }// This Attribut is jsut for the Multivalue Category
        public string primary_url { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string formatted_url { get; set; }
        public string primary { get; set; }
        public string description { get; set; }
    }
}
