using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Calendar
{
    public class TimeframeDTO
    {
        [JsonPropertyName("minDate")]
        public DateTimeOffset MinDate { get; set; }

        [JsonPropertyName("maxDate")]
        public DateTimeOffset MaxDate { get; set; }
    }
}
