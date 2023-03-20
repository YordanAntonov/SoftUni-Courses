using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class ExportUserProductsDto
    {
        [JsonProperty("usersCount")]
        public int UsersCount { get; set; }

        [JsonProperty("users")]
        public ExportUserNameAndAgeDto[]? Users { get; set; }
    }
}
