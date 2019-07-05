using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Request
{
    public class Formfactor : IRequest
    {
        public int category_id { get; set; }
        public int formfactor { get; set; }
        public int rackunits { get; set; }
        public int unit { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public int weight_unit { get; set; }
        public string description { get; set; } 
    }
}
