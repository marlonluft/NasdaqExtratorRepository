using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.External;
using NasdaqExtrator.Core.Repository;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;
using NasdaqExtrator.Core.Util;

namespace NasdaqExtrator.Core.Service
{
    public class StockService : IStockService
    {
        private readonly INasdaqAPIExternal _NasdaqAPIExternal;
        private readonly IStockRepository _stockRepository;

        public StockService(INasdaqAPIExternal NasdaqAPIExternal, IStockRepository stockRepository)
        {
            _NasdaqAPIExternal = NasdaqAPIExternal;
            _stockRepository = stockRepository;
        }

        public void ImportCompleteStock(string simbolo)
        {
            var stock = ImportarStock(simbolo);

            ImportarStockDividendos(stock, simbolo);
            ImportarStockPrecos(stock, simbolo);

            _stockRepository.Save(stock);
        }

        private StockEntity ImportarStock(string simbolo)
        {
            var stockInfoTask = _NasdaqAPIExternal.GetStockInfo(simbolo);
            Task.WaitAll(stockInfoTask);

            var stockInfoResult = stockInfoTask.Result;

            var stock = new StockEntity(stockInfoResult.Data.Symbol, stockInfoResult.Data.CompanyName);

            return stock;
        }

        private void ImportarStockDividendos(StockEntity stock, string simbolo)
        {
            var stockDividendsTask = _NasdaqAPIExternal.GetStockDividends(simbolo);
            Task.WaitAll(stockDividendsTask);

            var stockDividendsResult = stockDividendsTask.Result;

            foreach (var historico in stockDividendsResult.Data.Dividends.Rows)
            {
                if (!historico.PaymentDate.Equals("N/A"))
                {
                    var dividendValue = Helper.ParseNasdaqValue(historico.Amount);
                    var paymentDate = Helper.ParseNasdaqDate(historico.PaymentDate);

                    stock.Dividends.Historico.Add(new StockDataValueEntity(dividendValue, paymentDate));
                }
            }

            stock.Dividends.CalculateAverage();
        }

        private void ImportarStockPrecos(StockEntity stock, string simbolo)
        {
            var stockInfoTask = _NasdaqAPIExternal.GetStockInfo(simbolo);
            Task.WaitAll(stockInfoTask);

            var stockInfoResult = stockInfoTask.Result.Data;

            var lastPrice = Helper.ParseNasdaqValue(stockInfoResult.PrimaryData.LastSalePrice);

            stock.Prices.Historico.Add(new StockDataValueEntity(lastPrice, DateTime.UtcNow));

            // TODO calcular média
        }
    }
}
