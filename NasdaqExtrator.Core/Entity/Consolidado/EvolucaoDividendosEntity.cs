using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NasdaqExtrator.Core.Entity.Consolidado
{
    public class EvolucaoDividendosEntity
    {
        public EvolucaoDividendosEntity(string simbolo, int quantidadeMediaDividendosPagos, List<EvolucaoDividendosAnoEntity> anos)
        {
            Simbolo = simbolo;
            QuantidadeMediaDividendosPagos = quantidadeMediaDividendosPagos;
            Anos = anos;
            PercentualVariacao = CalcularVariacao();
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Simbolo { get; set; }
        public List<EvolucaoDividendosAnoEntity> Anos { get; set; }        
        public int QuantidadeMediaDividendosPagos { get; set; }
        public decimal? PercentualVariacao { get; set; }

        private decimal? CalcularVariacao()
        {
            if (Anos.Count <= 1)
            {
                return null;
            }

            var variacoes = new List<decimal>();

            for (int i = 1; i < Anos.Count; i++)
            {
                var valorAnoAnterior = Anos[i - 1].ValorMedioDividendo;
                var variacao = (Anos[i].ValorMedioDividendo / valorAnoAnterior) * 100;

                variacoes.Add(variacao);
            }

            return variacoes.Sum(x => x) / variacoes.Count;
        }
    }
}
