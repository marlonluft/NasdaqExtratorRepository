using MongoDB.Driver;
using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.Settings;

namespace NasdaqExtrator.Core.Repository
{
    public class DividendHistoryRepository : IDividendHistoryRepository
    {
        private readonly IMongoCollection<DividendHistoryEntity> _db;

        public DividendHistoryRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _db = database.GetCollection<DividendHistoryEntity>(settings.DividendHistoryCollectionName);
        }

        public void Gravar(DividendHistoryEntity entity)
        {
            _db.InsertOne(entity);
        }
    }
}
