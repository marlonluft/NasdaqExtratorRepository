using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Quote.Dividends
{
    public class DividendsDTO
    {
        [JsonPropertyName("headers")]
        public HeadersDTO Headers { get; set; }

        [JsonPropertyName("rows")]
        public List<HeadersDTO> Rows { get; set; }
    }
}
