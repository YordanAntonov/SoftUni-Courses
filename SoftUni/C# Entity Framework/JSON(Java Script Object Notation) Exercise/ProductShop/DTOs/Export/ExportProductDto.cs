using Newtonsoft.Json;
using ProductShop.Models;

namespace ProductShop.DTOs.Export
{
    public class ExportProductDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; } = null!;
    }
}
