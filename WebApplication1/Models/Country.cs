namespace WebApplication1.Models
{
 
        public class Country
        {
            public int CountryId { get; set; }
            public string CountryName { get; set; }

            public ICollection<Contact> Contacts { get; set; }
        }
    
}
