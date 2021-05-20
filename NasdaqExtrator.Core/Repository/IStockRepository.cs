using NasdaqExtrator.Core.Entity;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Repository
{
    public interface IStockRepository
    {
        void Save(StockEntity stock);
        StockEntity Find(string symbol);
        List<string> ListAllSymbols();
        List<StockEntity> ListAll();
    }
}
