using WebApplication1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebApplication1.Services
{
    public interface IContactsService
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContact(int id);
        Task<Contact> CreateContact(Contact contact);
        Task<Contact> UpdateContact(int id, Contact contact);
        Task<bool> DeleteContact(int id);
        Task<IEnumerable<Contact>> FilterContacts(int? countryId, int? companyId);
    }
}
