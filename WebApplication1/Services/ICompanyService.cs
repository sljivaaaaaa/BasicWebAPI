using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int id);
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(int id, Company company);
        Task<bool> DeleteCompany(int id);
    }
}
