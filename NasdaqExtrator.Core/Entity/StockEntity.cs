using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NasdaqExtrator.Core.Entity
{
    public class StockEntity
    {
        internal StockEntity()
        {
            Prices = new StockDataEntity();
            Dividends = new StockDataEntity();
        }

        public StockEntity(string symbol, string name) : this()
        {
            Symbol = symbol;
            Name = name;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public StockDataEntity Prices { get; set; }

        public StockDataEntity Dividends { get; set; }
    }
}
