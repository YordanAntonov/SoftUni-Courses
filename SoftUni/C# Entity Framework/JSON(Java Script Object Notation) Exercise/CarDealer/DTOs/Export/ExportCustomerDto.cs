using Newtonsoft.Json;

namespace CarDealer.DTOs.Export
{
    public class ExportCustomerDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("BirthDate")]
        public string? BirthDate { get; set; }

        [JsonProperty("IsYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
