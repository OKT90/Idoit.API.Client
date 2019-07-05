using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Request
{
    public  class Memory : IRequest
    {
        public int category_id { get; set; }// This Attribut is jsut for the Multi-value category
        public int quantity { get; set; }
        public int title { get; set; }
        public int manufacturer { get; set; }
        public int type { get; set; }
        public float total_capacity { get; set; }
        public float capacity { get; set; }
        public int unit { get; set; }
        public string description { get; set; }
    }
}
