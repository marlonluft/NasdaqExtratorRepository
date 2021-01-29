using MongoDB.Bson;
using MongoDB.Driver;
using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.Settings;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly IMongoCollection<StockEntity> _stock;

        public StockRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _stock = database.GetCollection<StockEntity>(settings.StockCollectionName);
        }

        public void AtualizarDividendos(ObjectId id, List<StockDividendEntity> dividendos)
        {
            var filter = Builders<StockEntity>.Filter.Eq(s => s.Id, id);
            var update = Builders<StockEntity>.Update.PushEach(s => s.Dividendos, dividendos);

            _stock.UpdateOne(filter, update);
        }

        public StockEntity Buscar(ObjectId stockId)
        {
            var filter = Builders<StockEntity>.Filter.Eq(s => s.Id, stockId);
            return _stock.Find(filter).FirstOrDefault();
        }

        public ObjectId GravarStock(StockEntity stock)
        {
            //var filter = Builders<StockEntity>.Filter.Eq(s => s.Id, stock.Id);
            _stock.InsertOne(stock);

            return stock.Id;

        }
    }
}
