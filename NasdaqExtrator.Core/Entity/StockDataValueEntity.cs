using MongoDB.Bson;
using System;

namespace NasdaqExtrator.Core.Entity
{
    public class StockDataValueEntity
    {
        internal StockDataValueEntity()
        {

        }

        public StockDataValueEntity(decimal value, DateTime date) : this()
        {
            Value = value;
            Date = date;
        }

        public decimal Value { get; set; }

        public BsonDateTime Date { get; set; }
    }
}
