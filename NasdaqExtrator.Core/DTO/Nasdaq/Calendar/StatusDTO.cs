using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Calendar
{
    public class StatusDTO
    {
        [JsonPropertyName("rCode")]
        public long RCode { get; set; }

        [JsonPropertyName("bCodeMessage")]
        public object BCodeMessage { get; set; }

        [JsonPropertyName("developerMessage")]
        public object DeveloperMessage { get; set; }
    }
}
