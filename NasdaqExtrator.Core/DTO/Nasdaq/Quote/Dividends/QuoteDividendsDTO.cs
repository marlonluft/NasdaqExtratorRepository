﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NasdaqExtrator.Core.DTO.Quote.Dividends
{
    public class QuoteDividendsDTO
    {
        [JsonPropertyName("data")]
        public DataDTO Data { get; set; }

        [JsonPropertyName("message")]
        public object Message { get; set; }

        [JsonPropertyName("status")]
        public StatusDTO Status { get; set; }
    }
}
