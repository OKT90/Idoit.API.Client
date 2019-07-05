using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Request
{
    public class Location : IRequest
    {
        public int category_id { get; set; }
        public string location_path { get; set; }
        public string parent { get; set; }
        public string option { get; set; }
        public string insertion { get; set; }
        public string pos { get; set; }
        public string gps { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string snmp_syslocation { get; set; }
        public string description { get; set; }
    }
}
