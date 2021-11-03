
namespace Idoit.API.Client.CMDB.Category.Request
{
    public class PersonsLogin : IRequest
    {
        public int category_id { get; set; }
        public string disabled_login { get; set; }
        public string title { get; set; }
        public string user_pass { get; set; }
        public string user_pass2 { get; set; }
        public string description { get; set; }
    }
}
