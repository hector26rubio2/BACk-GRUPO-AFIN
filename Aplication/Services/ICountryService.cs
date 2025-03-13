namespace Aplication.Services
{

    using Aplication.DTOs;
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetCountriesAsync();
        Task<IEnumerable<CountryDto>> GetCountriesByRegionAsync(string region);
        Task<IEnumerable<CountryDto>> GetCountriesByNameAsync(string name);

    }
}
