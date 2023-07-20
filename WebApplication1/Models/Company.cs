namespace WebApplication1.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
