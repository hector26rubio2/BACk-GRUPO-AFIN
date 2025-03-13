
namespace Common.Services
{
    public interface ICountryProxy
    {
        Task<IEnumerable<T>> GetCountriesAsync<T>();
        Task<IEnumerable<T>> GetCountriesByRegionAsync<T>(string region);
        Task<IEnumerable<T>> GetCountriesByNameAsync<T>(string name);
       }
}
