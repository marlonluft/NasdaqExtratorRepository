using MongoDB.Bson;

namespace NasdaqExtrator.Core.Service
{
    public interface IStockService
    {
        void ImportarStockCompleto(string simbolo);
        void ImportarStockDividendos(ObjectId stockId);
        void ImportarStockPrecos(ObjectId stockId);
    }
}
