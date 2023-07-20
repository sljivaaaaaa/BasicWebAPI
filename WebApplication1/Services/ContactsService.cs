// ContactsService.cs
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class ContactsService : IContactsService
    {
        private readonly AppDbContext _context;

        public ContactsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContact(int id, Contact contact)
        {
            if (id != contact.ContactId)
            {
                return null;
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return contact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Contact>> FilterContacts(int? countryId, int? companyId)
        {
            var contactsQuery = _context.Contacts.AsQueryable();

            if (countryId.HasValue)
            {
                contactsQuery = contactsQuery.Where(c => c.CountryID == countryId.Value);
            }

            if (companyId.HasValue)
            {
                contactsQuery = contactsQuery.Where(c => c.CompanyId == companyId.Value);
            }

            return await contactsQuery.ToListAsync();
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactId == id);
        }
    }
}
