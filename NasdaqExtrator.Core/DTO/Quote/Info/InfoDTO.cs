using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Quote.Info
{
    public class InfoDTO
    {
        [JsonPropertyName("data")]
        public DataDTO Data { get; set; }

        [JsonPropertyName("message")]
        public object Message { get; set; }

        [JsonPropertyName("status")]
        public StatusDTO Status { get; set; }
    }
}
