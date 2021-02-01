using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Entity.Consolidado
{
    public class StockEvolucaoEntity
    {
        public StockEvolucaoEntity()
        {

        }

        public StockEvolucaoEntity(string simbolo, List<StockEvolucaoAnoEntity> anos)
        {
            Simbolo = simbolo;
            Anos = anos;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Simbolo { get; set; }
        public List<StockEvolucaoAnoEntity> Anos { get; set; }
    }
}
