using Newtonsoft.Json;

namespace Idoit.API.Client.CMDB.Category.Request
{
    public class Diary : IRequest
    {
        public int category_id { get; set; }// This Attribut is jsut for the Multivalue Category
        public string f_popup_c_1581927717973 { get; set; } //Datum
        public int f_popup_c_1581927723207 { get; set; } //Author
        public string f_wysiwyg_c_1581927732804 { get; set; } //Entry
        public string description { get; set; } //
    }
}
