namespace Aplication.Services.Impl
{
    using Aplication.DTOs;
    using Aplication.Services;
    using AutoMapper;
    using Common.Services;
    using Domain.Models;

    public class CountryService : ICountryService
    {
        private readonly ICountryProxy _countryProxy;
        private readonly IMapper _mapper;

        public CountryService( IMapper mapper, ICountryProxy countryProxy)
        {
            _countryProxy = countryProxy;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        {
            var countries = await  _countryProxy.GetCountriesAsync<Country>();
            var dtos = _mapper.Map<IEnumerable<CountryDto>>(countries);
            return dtos;
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesByNameAsync(string name)
        {
            var countries = await _countryProxy.GetCountriesByNameAsync<Country>(name);
            var dtos = _mapper.Map<IEnumerable<CountryDto>>(countries);
            return dtos;
        }


        public async Task<IEnumerable<CountryDto>> GetCountriesByRegionAsync(string region)
        {
            var countries = await _countryProxy.GetCountriesByRegionAsync<Country>(region);
            var dtos = _mapper.Map<IEnumerable<CountryDto>>(countries);
            return dtos;
        }
    }
}
