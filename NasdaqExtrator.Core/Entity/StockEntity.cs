using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Entity
{
    public class StockEntity
    {
        internal StockEntity()
        {
            Precos = new List<StockPriceEntity>();
            Dividendos = new List<StockDividendEntity>();
        }

        public StockEntity(string simbolo, string nome) : this()
        {
            Simbolo = simbolo;
            Nome = nome;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Simbolo { get; set; }

        public string Nome { get; set; }

        public List<StockPriceEntity> Precos { get; set; }

        public List<StockDividendEntity> Dividendos { get; set; }
    }
}
