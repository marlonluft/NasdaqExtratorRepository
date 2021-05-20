using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Quote.Info
{
    public class PrimaryDataDTO
    {
        [JsonPropertyName("lastSalePrice")]
        public string LastSalePrice { get; set; }

        [JsonPropertyName("netChange")]
        public string NetChange { get; set; }

        [JsonPropertyName("percentageChange")]
        public string PercentageChange { get; set; }

        [JsonPropertyName("deltaIndicator")]
        public string DeltaIndicator { get; set; }

        [JsonPropertyName("lastTradeTimestamp")]
        public string LastTradeTimestamp { get; set; }

        [JsonPropertyName("isRealTime")]
        public bool IsRealTime { get; set; }
    }
}
