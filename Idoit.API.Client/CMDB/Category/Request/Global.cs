using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category.Request
{
   public class Global : IRequest
   {
        public int category_id { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string created { get; set; }
        public string created_by { get; set; }
        public string changed { get; set; }
        public string changed_by { get; set; }
        public int purpose { get; set; }
        public int category { get; set; }
        public string sysid { get; set; }
        public int cmdb_status { get; set; }
        public int type { get; set; }
        public string [] tag { get; set; }
        public string description { get; set; }
   }
}
