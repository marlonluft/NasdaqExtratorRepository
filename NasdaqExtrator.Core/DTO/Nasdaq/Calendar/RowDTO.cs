using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Calendar
{
    public class RowDTO
    {
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("dividend_Ex_Date")]
        public string DividendExDate { get; set; }

        [JsonPropertyName("payment_Date")]
        public string PaymentDate { get; set; }

        [JsonPropertyName("record_Date")]
        public string RecordDate { get; set; }

        [JsonPropertyName("dividend_Rate")]
        public decimal DividendRate { get; set; }

        [JsonPropertyName("indicated_Annual_Dividend")]
        public decimal IndicatedAnnualDividend { get; set; }

        [JsonPropertyName("announcement_Date")]
        public string AnnouncementDate { get; set; }
    }
}
