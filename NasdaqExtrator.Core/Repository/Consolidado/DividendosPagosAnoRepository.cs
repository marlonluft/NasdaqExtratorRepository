using MongoDB.Driver;
using NasdaqExtrator.Core.Entity.Consolidado;
using NasdaqExtrator.Core.Settings;

namespace NasdaqExtrator.Core.Repository.Consolidado
{
    public class DividendosPagosAnoRepository : IDividendosPagosAnoRepository
    {
        private readonly IMongoCollection<DividendosPagosAnoEntity> _db;

        public DividendosPagosAnoRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _db = database.GetCollection<DividendosPagosAnoEntity>(settings.DividendosPagosAnoCollectionName);
        }

        public void Gravar(DividendosPagosAnoEntity entity)
        {
            _db.InsertOne(entity);
        }
    }
}
