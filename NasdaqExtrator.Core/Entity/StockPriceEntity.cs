using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NasdaqExtrator.Core.Entity
{
    public class StockPriceEntity
    {
        internal StockPriceEntity()
        {

        }

        public StockPriceEntity(decimal precoFechamento, DateTime data) : this()
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
