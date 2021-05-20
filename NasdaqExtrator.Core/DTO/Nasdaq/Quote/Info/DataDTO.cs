using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Quote.Info
{
    public class DataDTO
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("stockType")]
        public string StockType { get; set; }

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("isNasdaqListed")]
        public bool IsNasdaqListed { get; set; }

        [JsonPropertyName("isNasdaq100")]
        public bool IsNasdaq100 { get; set; }

        [JsonPropertyName("isHeld")]
        public bool IsHeld { get; set; }

        [JsonPropertyName("primaryData")]
        public PrimaryDataDTO PrimaryData { get; set; }

        [JsonPropertyName("secondaryData")]
        public object SecondaryData { get; set; }

        [JsonPropertyName("keyStats")]
        public KeyStatsDTO KeyStats { get; set; }

        [JsonPropertyName("marketStatus")]
        public string MarketStatus { get; set; }

        [JsonPropertyName("assetClass")]
        public string AssetClass { get; set; }
    }
}
