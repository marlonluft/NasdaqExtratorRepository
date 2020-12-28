using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Quote.Info
{
    public class KeyStatsDTO
    {
        [JsonPropertyName("Volume")]
        public MarketCapDTO Volume { get; set; }

        [JsonPropertyName("PreviousClose")]
        public MarketCapDTO PreviousClose { get; set; }

        [JsonPropertyName("OpenPrice")]
        public MarketCapDTO OpenPrice { get; set; }

        [JsonPropertyName("MarketCap")]
        public MarketCapDTO MarketCap { get; set; }
    }
}
