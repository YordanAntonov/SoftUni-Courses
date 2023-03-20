using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    public class ExportUserNameAndAgeDto
    {
        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("soldProducts")]
        public ExportProductCountAndListDto[]? SoldProducts { get; set; }
    }
}
