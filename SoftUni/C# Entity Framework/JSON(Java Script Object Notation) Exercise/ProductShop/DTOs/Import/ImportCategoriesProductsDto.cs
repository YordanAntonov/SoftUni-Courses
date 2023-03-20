using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    public class ImportCategoriesProductsDto
    {
        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("ProductId")]
        public int ProductId { get; set; }
    }
}
