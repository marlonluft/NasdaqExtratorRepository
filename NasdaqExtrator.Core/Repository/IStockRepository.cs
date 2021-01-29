using MongoDB.Bson;
using NasdaqExtrator.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NasdaqExtrator.Core.Repository
{
    public interface IStockRepository
    {
        ObjectId GravarStock(StockEntity stock);
        void AtualizarDividendos(ObjectId id, List<StockDividendEntity> dividendos);
    }
}
