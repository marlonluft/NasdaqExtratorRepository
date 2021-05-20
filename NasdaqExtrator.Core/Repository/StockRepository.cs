using MongoDB.Driver;
using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.Settings;
using System.Collections.Generic;
using System.Linq;

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

        public StockEntity Find(string symbol)
        {
            var filter = Builders<StockEntity>.Filter.Eq(s => s.Symbol, symbol);
            return _stock.Find(filter).FirstOrDefault();
        }

        public List<StockEntity> ListAll()
        {
            return _stock.AsQueryable().ToList();
        }

        public List<string> ListAllSymbols()
        {
            return _stock.AsQueryable().Select(x => x.Symbol).ToList();
        }

        public void Save(StockEntity stock)
        {
            var filter = Builders<StockEntity>.Filter.Eq(s => s.Id, stock.Id);

            if(_stock.CountDocuments(filter) > 0)
            {
                var update = Builders<StockEntity>.Update
                .Set(m => m.Id, stock.Id)
                .Set(m => m.Name, stock.Name)
                .Set(m => m.Dividends, stock.Dividends)
                .Set(m => m.Prices, stock.Prices)
                .Set(p => p.Symbol, stock.Symbol);

                _stock.UpdateOne(filter, update);
            }
            else
            {
                _stock.InsertOne(stock);
            }
        }
    }
}
