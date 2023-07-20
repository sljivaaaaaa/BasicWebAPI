using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _contactsService.GetContacts());
        }

        // GET: api/Contacts/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactsService.GetContact(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // GET: api/Contacts/1/WithCompanyAndCountry
        [HttpGet("{id}/WithCompanyAndCountry")]
        public async Task<ActionResult<Contact>> GetContactWithCompanyAndCountry(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 64 
            };

            var contact = await _contactsService.GetContact(id);

            if (contact == null)
            {
                return NotFound();
            }

            var serializedContact = JsonSerializer.Serialize(contact, options);
            return Content(serializedContact, "application/json");
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            var createdContact = await _contactsService.CreateContact(contact);
            return CreatedAtAction(nameof(GetContact), new { id = createdContact.ContactId }, createdContact);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            var updatedContact = await _contactsService.UpdateContact(id, contact);
            if (updatedContact == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactsService.DeleteContact(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/Contacts/FilterContacts?countryId=1&companyId=2
        [HttpGet("FilterContacts")]
        public async Task<ActionResult<IEnumerable<Contact>>> FilterContacts(int? countryId, int? companyId)
        {
            var filteredContacts = await _contactsService.FilterContacts(countryId, companyId);
            return Ok(filteredContacts);
        }
    }
}
