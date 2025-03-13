namespace Aplication.DTOs
{
    public class CountryDto
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public long Population { get; set; }
        public Dictionary<string, string> Languages { get; set; }
        public string Flag { get; set; }
    }

}
