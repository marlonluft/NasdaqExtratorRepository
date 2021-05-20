using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Quote.Dividends
{
    public class StatusDTO
    {
        [JsonPropertyName("rCode")]
        public long RCode { get; set; }

        [JsonPropertyName("bCodeMessage")]
        public object BCodeMessage { get; set; }

        [JsonPropertyName("developerMessage")]
        public object DeveloperMessage { get; set; }
    }
}
