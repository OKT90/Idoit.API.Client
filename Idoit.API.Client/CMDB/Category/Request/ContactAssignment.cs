namespace Idoit.API.Client.CMDB.Category.Request
{
    public class ContactAssignment : IRequest
    {
        public int category_id { get; set; }// This Attribut is just for the MV Category
        public int contact { get; set; }
        public string primary_contact { get; set; }
        public string contact_object { get; set; }
        public string primary { get; set; }
        public int role { get; set; }
        public string contact_list { get; set; }
        public string description { get; set; }
    }
}
