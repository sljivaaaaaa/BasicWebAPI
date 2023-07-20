namespace WebApplication1.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int CompanyId { get; set; }
        public int CountryID { get; set; }

        public Company Company { get; set; }
        public Country Country { get; set; }
    }
}
