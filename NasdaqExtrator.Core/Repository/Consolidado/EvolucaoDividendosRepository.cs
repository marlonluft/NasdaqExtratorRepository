using MongoDB.Driver;
using NasdaqExtrator.Core.Entity.Consolidado;
using NasdaqExtrator.Core.Settings;
using System.Collections.Generic;
using System.Linq;

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

        public void GravarLista(List<EvolucaoDividendosEntity> lista)
        {
            var filter = Builders<EvolucaoDividendosEntity>.Filter.In(s => s.Simbolo, lista.Select(x => x.Simbolo).ToArray());

            _db.DeleteMany(filter);
            _db.InsertMany(lista);
        }

        public List<EvolucaoDividendosEntity> ListarEstaveisDecrescente(int quantidadeRegistros)
        {
            return _db
                .Find(x => x.PercentualVariacao.HasValue)
                .SortBy(x => x.PercentualVariacao)
                .Limit(quantidadeRegistros)
                .ToList();
        }
    }
}
