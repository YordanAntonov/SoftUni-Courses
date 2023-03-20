using Newtonsoft.Json;

namespace CarDealer.DTOs.Export
{
    public class ExportPartDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Price")]
        public string Price { get; set; }
    }
}
