using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NasdaqExtrator.Core.Entity
{
    public class StockPriceModel
    {
        internal StockPriceModel()
        {

        }

        public StockPriceModel(decimal precoFechamento, DateTime data)
        {
            PrecoFechamento = precoFechamento;
            Data = data;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public decimal PrecoFechamento { get; set; }

        public DateTime Data { get; set; }
    }
}
