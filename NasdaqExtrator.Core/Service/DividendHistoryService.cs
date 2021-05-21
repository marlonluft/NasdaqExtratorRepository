using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.External;
using NasdaqExtrator.Core.Repository;
using NasdaqExtrator.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NasdaqExtrator.Core.Service
{
    public class DividendHistoryService : IDividendHistoryService
    {
        private readonly INasdaqAPIExternal _NasdaqAPIExternal;
        private readonly IStockRepository _stockRepository;
        private readonly IStockService _stockService;

        public DividendHistoryService(INasdaqAPIExternal NasdaqAPIExternal, IStockRepository stockRepository, IStockService stockService)
        {
            _NasdaqAPIExternal = NasdaqAPIExternal;
            _stockRepository = stockRepository;
            _stockService = stockService;
        }

        public void ImportarHistorico(DateTime data)
        {
            var dividendsTask = _NasdaqAPIExternal.GetDividends(data);
            Task.WaitAll(dividendsTask);

            var dividendsResult = dividendsTask.Result;
            var storedSymbols = _stockRepository.ListAllSymbols();

            if (dividendsResult.Status.RCode == 200 && dividendsResult.Data.Calendar.Rows?.Count > 0)
            {
                var stocksToImport = new List<string>();

                Parallel.ForEach(dividendsResult.Data.Calendar.Rows, (historico) =>
                {
                    var existInDatabase = false;

                    lock (storedSymbols)
                    {
                        existInDatabase = storedSymbols.Any(x => x == historico.Symbol);
                    }

                    if (existInDatabase)
                    {
                        if (!historico.PaymentDate.Equals("N/A"))
                        {
                            var paymentDate = Helper.ParseNasdaqDate(historico.PaymentDate);
                            var value = historico.DividendRate;

                            var stock = _stockRepository.Find(historico.Symbol);

                            if (!stock.Dividends.Historico.Any(x => x.Date == paymentDate))
                            {
                                stock.Dividends.Historico.Add(new StockDataValueEntity(value, paymentDate));
                                stock.Dividends.CalculateAverage();

                                _stockRepository.Save(stock);
                            }
                        }
                    }
                    else
                    {
                        lock (stocksToImport)
                        {
                            stocksToImport.Add(historico.Symbol);
                        }
                    }
                });

                ImportStocks(stocksToImport);
            }
        }

        private void ImportStocks(List<string> symbols)
        {
            Parallel.ForEach(symbols.Distinct(), (string symbol) =>
            {
                _stockService.ImportCompleteStock(symbol);
            });
        }
    }
}
