using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.External;
using NasdaqExtrator.Core.Repository;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;
using NasdaqExtrator.Core.Util;
using Microsoft.Extensions.Logging;

namespace NasdaqExtrator.Core.Service
{
    public class StockService : IStockService
    {
        private readonly INasdaqAPIExternal _NasdaqAPIExternal;
        private readonly IStockRepository _stockRepository;
        private readonly ILogger<StockService> _logger;

        public StockService(INasdaqAPIExternal NasdaqAPIExternal, IStockRepository stockRepository, ILogger<StockService> logger)
        {
            _NasdaqAPIExternal = NasdaqAPIExternal;
            _stockRepository = stockRepository;
            _logger = logger;
        }

        public void ImportCompleteStock(string simbolo)
        {
            try
            {
                var stock = ImportarStock(simbolo);

                if (stock != null)
                {
                    ImportarStockDividendos(stock, simbolo);
                    ImportarStockPrecos(stock, simbolo);

                    _stockRepository.Save(stock);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("ImportCompleteStock", ex);
            }
        }

        private StockEntity ImportarStock(string simbolo)
        {
            var stockInfoTask = _NasdaqAPIExternal.GetStockInfo(simbolo);
            Task.WaitAll(stockInfoTask);

            var stockInfoResult = stockInfoTask.Result;

            if (stockInfoResult.Data == null)
            {
                return null;
            }

            var stock = new StockEntity(stockInfoResult.Data.Symbol, stockInfoResult.Data.CompanyName);

            return stock;
        }

        private void ImportarStockDividendos(StockEntity stock, string simbolo)
        {
            var stockDividendsTask = _NasdaqAPIExternal.GetStockDividends(simbolo);
            Task.WaitAll(stockDividendsTask);

            var stockDividendsResult = stockDividendsTask.Result;

            if (stockDividendsResult.Data != null)
            {
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
