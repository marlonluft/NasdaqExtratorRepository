using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Entity.Consolidado
{
    public class EvolucaoDividendosEntity
    {
        public EvolucaoDividendosEntity(string simbolo, int quantidadeMediaDividendosPagos, List<EvolucaoDividendosAnoEntity> anos)
        {
            Simbolo = simbolo;
            QuantidadeMediaDividendosPagos = quantidadeMediaDividendosPagos;
            Anos = anos;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Simbolo { get; set; }
        public List<EvolucaoDividendosAnoEntity> Anos { get; set; }
        public int QuantidadeMediaDividendosPagos { get; set; }
    }
}
