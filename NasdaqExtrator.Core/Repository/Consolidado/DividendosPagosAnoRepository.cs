using MongoDB.Driver;
using NasdaqExtrator.Core.Entity.Consolidado;
using NasdaqExtrator.Core.Settings;
using System.Collections.Generic;

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

        public void GravarLista(List<DividendosPagosAnoEntity> entities)
        {
            //TODO: atualizar existentes para não duplicar
            _db.InsertMany(entities);
        }

        public List<DividendosPagosAnoEntity> ListarValorTotalPagoDecrescente(int ano, int quantidadeRegistros)
        {
            return _db
                .Find(x => x.Ano == ano)
                .SortByDescending(x => x.ValorTotalPago)
                .Limit(quantidadeRegistros)
                .ToList();
        }
    }
}
