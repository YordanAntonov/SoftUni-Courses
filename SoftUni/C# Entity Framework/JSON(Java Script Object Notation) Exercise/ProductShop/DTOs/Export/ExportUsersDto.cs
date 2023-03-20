using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class ExportUsersDto
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;

        [JsonProperty("soldProducts")]
        public ExportUserSoldProductsDto[]? ProductsSold { get; set; }
    }
}
