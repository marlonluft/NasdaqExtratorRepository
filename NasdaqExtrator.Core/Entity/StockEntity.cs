using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Entity
{
    public class StockEntity
    {
        internal StockEntity()
        {

        }

        public StockEntity(string simbolo, string nome, List<StockPriceEntity> precos, List<StockDividendEntity> dividendos)
        {
            Simbolo = simbolo;
            Nome = nome;
            Precos = precos;
            Dividendos = dividendos;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Simbolo { get; set; }

        public string Nome { get; set; }

        public List<StockPriceEntity> Precos { get; set; }

        public List<StockDividendEntity> Dividendos { get; set; }
    }
}
