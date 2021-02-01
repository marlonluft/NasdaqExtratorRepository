using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NasdaqExtrator.Core.Service
{
    public class DividendHistoryService : IDividendHistoryService
    {
        private readonly INasdaqAPIService _nasdaqApiService;
        private readonly IDividendHistoryRepository _dividendHistoryRepository;

        public DividendHistoryService(INasdaqAPIService nasdaqApiService, IDividendHistoryRepository dividendHistoryRepository)
        {
            _nasdaqApiService = nasdaqApiService;
            _dividendHistoryRepository = dividendHistoryRepository;
        }

        public void ImportarHistorico(DateTime data)
        {
            var dividendsTask = _nasdaqApiService.GetDividends(data);

            Task.WaitAll(dividendsTask);

            var dividendsResult = dividendsTask.Result;

            Parallel.ForEach(dividendsResult.Data.Calendar.Rows, (historico) =>
            {
                var dataPagamento = DateTime.ParseExact(historico.PaymentDate, "MM/dd/yyyy", null);

                var dividendo = new DividendHistoryEntity(historico.Symbol, dataPagamento, historico.DividendRate);
                _dividendHistoryRepository.Gravar(dividendo);
            });
        }

        public List<DividendHistoryEntity> Listar(int anoConsolidar)
        {
            return _dividendHistoryRepository.Listar(anoConsolidar);
        }
    }
}
