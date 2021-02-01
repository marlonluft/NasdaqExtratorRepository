using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NasdaqExtrator.Core.Entity.Consolidado
{
    public class DividendosPagosAnoEntity
    {
        internal DividendosPagosAnoEntity()
        {

        }

        public DividendosPagosAnoEntity(
            string simbolo,
            decimal valorMedioPago,
            decimal valorTotalPago,
            int quantidadePaga,
            int ano) : this()
        {
            Simbolo = simbolo;
            ValorMedioPago = valorMedioPago;
            ValorTotalPago = valorTotalPago;
            QuantidadePaga = quantidadePaga;
            Ano = ano;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Simbolo { get; set; }
        public decimal ValorMedioPago { get; set; }
        public decimal ValorTotalPago { get; set; }
        public int QuantidadePaga { get; set; }
        public int Ano { get; set; }
    }
}
