using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return Ok(await _companyService.GetCompanies());
        }

        // GET: api/Companies/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyService.GetCompany(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // POST: api/Companies
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            var createdCompany = await _companyService.CreateCompany(company);
            return CreatedAtAction(nameof(GetCompany), new { id = createdCompany.CompanyId }, createdCompany);
        }

        // PUT: api/Companies/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            var updatedCompany = await _companyService.UpdateCompany(id, company);
            if (updatedCompany == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE: api/Companies/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await _companyService.DeleteCompany(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
