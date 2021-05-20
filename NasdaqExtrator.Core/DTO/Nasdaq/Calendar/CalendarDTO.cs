using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Calendar
{
    public class CalendarDTO
    {
        [JsonPropertyName("headers")]
        public HeadersDTO Headers { get; set; }

        [JsonPropertyName("rows")]
        public List<RowDTO> Rows { get; set; }
    }
}
