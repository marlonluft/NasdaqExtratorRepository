using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Quote.Dividends
{
    public class HeadersDTO
    {
        [JsonPropertyName("exOrEffDate")]
        public string ExOrEffDate { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("declarationDate")]
        public string DeclarationDate { get; set; }

        [JsonPropertyName("recordDate")]
        public string RecordDate { get; set; }

        [JsonPropertyName("paymentDate")]
        public string PaymentDate { get; set; }
    }
}
