using MongoDB.Bson;
using NasdaqExtrator.Core.Entity;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Repository
{
    public interface IStockRepository
    {
        ObjectId GravarStock(StockEntity stock);
        void AtualizarDividendos(ObjectId id, List<StockDividendEntity> dividendos);
        StockEntity Buscar(ObjectId stockId);
    }
}
