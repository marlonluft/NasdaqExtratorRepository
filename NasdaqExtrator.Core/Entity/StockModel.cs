using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Entity
{
    public class StockModel
    {
        internal StockModel()
        {

        }

        public StockModel(string simbolo, string nome, List<StockPriceModel> precos, List<StockDividendModel> dividendos)
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

        public List<StockPriceModel> Precos { get; set; }

        public List<StockDividendModel> Dividendos { get; set; }
    }
}
