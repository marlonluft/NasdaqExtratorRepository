﻿using MongoDB.Driver;
using NasdaqExtrator.Core.Entity.Consolidado;
using NasdaqExtrator.Core.Settings;

namespace NasdaqExtrator.Core.Repository.Consolidado
{
    public class EvolucaoDividendosRepository : IEvolucaoDividendosRepository
    {
        private readonly IMongoCollection<EvolucaoDividendosEntity> _db;

        public EvolucaoDividendosRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _db = database.GetCollection<EvolucaoDividendosEntity>(settings.EvolucaoDividendosCollectionName);
        }

        public void Gravar(EvolucaoDividendosEntity entity)
        {
            _db.InsertOne(entity);
        }
    }
}