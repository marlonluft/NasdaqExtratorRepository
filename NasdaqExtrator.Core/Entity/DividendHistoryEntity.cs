using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NasdaqExtrator.Core.Entity
{
    public class DividendHistoryEntity
    {
        internal DividendHistoryEntity()
        {

        }

        public DividendHistoryEntity(string simbolo, DateTime dataPagamento, decimal valor)
        {
            Valor = valor;
            DataPagamento = dataPagamento;
            Simbolo = simbolo;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Simbolo { get; set; }

        public BsonDateTime DataPagamento { get; set; }

        public decimal Valor { get; set; }
    }
}
