namespace Api.Controllers
{
    using Aplication.Services;
    using Microsoft.AspNetCore.Mvc;


    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _countryService.GetCountriesAsync();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Ocurrió un error al obtener la lista de países.", Details = ex.Message });
            }
        }

        [HttpGet("region/{region}")]
        public async Task<IActionResult> GetCountriesByRegion(string region)
        {
            try
            {
                var countries = await _countryService.GetCountriesByRegionAsync(region);
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Ocurrió un error al obtener los países de la región '{region}'.", Details = ex.Message });
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetCountriesByName(string name)
        {
            try
            {
                var countries = await _countryService.GetCountriesByNameAsync(name);
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Ocurrió un error al buscar países con el nombre '{name}'.", Details = ex.Message });
            }
        }
    }
}

