using MongoDB.Driver;
using NasdaqExtrator.Core.Entity.Consolidado;
using NasdaqExtrator.Core.Settings;

namespace NasdaqExtrator.Core.Repository.Consolidado
{
    public class StockEvolucaoRepository : IStockEvolucaoRepository
    {
        private readonly IMongoCollection<StockEvolucaoEntity> _db;

        public StockEvolucaoRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _db = database.GetCollection<StockEvolucaoEntity>(settings.StockEvolucaoCollectionName);
        }

        public void Gravar(StockEvolucaoEntity entity)
        {
            _db.InsertOne(entity);
        }
    }
}
