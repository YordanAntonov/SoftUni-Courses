using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CarDealer.DTOs.Export
{
    [JsonObject("car")]
    public class ExportCarWithPartsDto
    {
        [JsonProperty("Make")]
        public string Make { get; set; } = null!;

        [JsonProperty("Model")]
        public string Model { get; set; } = null!;

        [JsonProperty("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [JsonProperty("parts")]
        public ExportPartDto[]? Parts { get; set; }
    }
}
