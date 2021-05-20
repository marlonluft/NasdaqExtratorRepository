using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Calendar
{
    public class DataDTO
    {
        [JsonPropertyName("calendar")]
        public CalendarDTO Calendar { get; set; }

        [JsonPropertyName("timeframe")]
        public TimeframeDTO Timeframe { get; set; }
    }
}
