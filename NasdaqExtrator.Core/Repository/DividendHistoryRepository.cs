using MongoDB.Driver;
using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.Settings;
using System;
using System.Collections.Generic;

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

        public List<DividendHistoryEntity> Listar(int anoConsolidar)
        {
            var primeiraDataAno = new DateTime(anoConsolidar, 1, 1);
            var ultimaDataAno = primeiraDataAno.AddYears(1).AddMilliseconds(-1);

            return _db
                .Find(x => x.DataPagamento >= primeiraDataAno && x.DataPagamento <= ultimaDataAno)
                .ToList();
        }
    }
}
