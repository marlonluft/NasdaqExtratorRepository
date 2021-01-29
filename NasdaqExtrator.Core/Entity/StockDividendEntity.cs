using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NasdaqExtrator.Core.Entity
{
    public class StockDividendEntity
    {
        internal StockDividendEntity()
        {

        }

        public StockDividendEntity(decimal valor, DateTime dataPagamento) : this()
        {
            Valor = valor;
            DataPagamento = dataPagamento;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public decimal Valor { get; set; }

        public BsonDateTime DataPagamento { get; set; }
    }
}
