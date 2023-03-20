using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class ExportUserSoldProductsDto
    {
        [JsonProperty("name")]
        public string ItemName { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("buyerFirstName")]
        public string? BuyerFirstName { get; set; }

        [JsonProperty("buyerLastName")]
        public string BuyerLastName { get; set; } = null!;

    }
}
