using MongoDB.Bson;
using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace NasdaqExtrator.Core.Service
{
    public class StockService : IStockService
    {
        private readonly INasdaqAPIService _nasdaqApiService;
        private readonly IStockRepository _stockRepository;

        public StockService(INasdaqAPIService nasdaqApiService, IStockRepository stockRepository)
        {
            _nasdaqApiService = nasdaqApiService;
            _stockRepository = stockRepository;
        }

        public void ImportarStockCompleto(string simbolo)
        {
            var stockId = ImportarStock(simbolo);
            ImportarStockDividendos(stockId, simbolo);
            ImportarStockPrecos(stockId, simbolo);
        }

        private ObjectId ImportarStock(string simbolo)
        {
            var stockInfoTask = _nasdaqApiService.GetStockInfo(simbolo);
            Task.WaitAll(stockInfoTask);

            var stockInfoResult = stockInfoTask.Result;

            var stock = new StockEntity(stockInfoResult.Data.Symbol, stockInfoResult.Data.CompanyName);

            return _stockRepository.GravarStock(stock);
        }

        public void ImportarStockDividendos(ObjectId stockId)
        {
            var stock = _stockRepository.Buscar(stockId);
            ImportarStockDividendos(stock.Id, stock.Simbolo);
        }

        private void ImportarStockDividendos(ObjectId stockId, string simbolo)
        {
            var stockDividendsTask = _nasdaqApiService.GetStockDividends(simbolo);
            Task.WaitAll(stockDividendsTask);

            var stockDividendsResult = stockDividendsTask.Result;

            var listaDividendos = new List<StockDividendEntity>();

            foreach (var historico in stockDividendsResult.Data.Dividends.Rows)
            {
                var valorDividendo = Convert.ToDecimal(historico.Amount, new CultureInfo("en-US"));
                var datapagamento = DateTime.ParseExact(historico.PaymentDate, "MM/dd/yyyy", null);

                listaDividendos.Add(new StockDividendEntity(valorDividendo, datapagamento));
            }

            _stockRepository.AtualizarDividendos(stockId, listaDividendos);
        }

        public void ImportarStockPrecos(ObjectId stockId)
        {
            var stock = _stockRepository.Buscar(stockId);
            ImportarStockPrecos(stock.Id, stock.Simbolo);
        }

        private void ImportarStockPrecos(ObjectId stockId, string simbolo)
        {
            var stockInfoTask = _nasdaqApiService.GetStockInfo(simbolo);
            Task.WaitAll(stockInfoTask);
        }
    }
}
