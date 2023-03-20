using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class ExportProductCountAndListDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("products")]
        public ExportProductProfileDto[]? Products { get; set; }
    }
}
