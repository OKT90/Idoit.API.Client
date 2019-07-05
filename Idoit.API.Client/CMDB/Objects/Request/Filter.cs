using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Objects.Request
{
   public class Filter
   {
        public int[] ids { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string type_itle { get; set; }
        public string sysid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
   }
}
