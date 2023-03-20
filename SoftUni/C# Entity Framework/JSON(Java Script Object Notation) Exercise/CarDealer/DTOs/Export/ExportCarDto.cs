using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CarDealer.DTOs.Export
{
    public class ExportCarDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Make")]
        public string Make { get; set; } = null!;

        [JsonProperty("Model")]
        public string Model { get; set; } = null!;

        [JsonProperty("TraveledDistance")]
        public long TraveledDistance { get; set; }
    }
}
