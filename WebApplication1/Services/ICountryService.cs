using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(int id);
        Task<Country> CreateCountry(Country country);
        Task<Country> UpdateCountry(int id, Country country);
        Task<bool> DeleteCountry(int id);
    }
}
