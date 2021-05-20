using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Quote.Dividends
{
    public class DataDTO
    {
        [JsonPropertyName("exDividendDate")]
        public string ExDividendDate { get; set; }

        [JsonPropertyName("dividendPaymentDate")]
        public string DividendPaymentDate { get; set; }

        [JsonPropertyName("yield")]
        public string Yield { get; set; }

        [JsonPropertyName("annualizedDividend")]
        public string AnnualizedDividend { get; set; }

        [JsonPropertyName("payoutRatio")]
        public string PayoutRatio { get; set; }

        [JsonPropertyName("dividends")]
        public DividendsDTO Dividends { get; set; }
    }
}
