using Microsoft.AspNetCore.Mvc;
using NasdaqExtrator.Core.Entity;
using NasdaqExtrator.Core.Repository;
using NasdaqExtrator.Core.Service;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace NasdaqExtrator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly INasdaqAPIService _nasdaqApiService;
        private readonly IStockRepository _stockRepository;        

        public PingController(INasdaqAPIService nasdaqApiService, IStockRepository stockRepository)
        {
            _nasdaqApiService = nasdaqApiService;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stockDividendsTask = _nasdaqApiService.GetStockDividends("IBM");
            var stockInfoTask = _nasdaqApiService.GetStockInfo("IBM");

            Task.WaitAll(stockDividendsTask, stockInfoTask);

            var stockResult = stockInfoTask.Result;
            var stockDividendsResult = stockDividendsTask.Result;

            var stock = new StockEntity(stockResult.Data.Symbol, stockResult.Data.CompanyName);

            var id = _stockRepository.GravarStock(stock);

            var dividendos = stockDividendsResult.Data.Dividends.Rows
                .Select(x => new StockDividendEntity(decimal.Parse(x.Amount.Replace("$", string.Empty)), DateTime.Parse(x.PaymentDate)))
                .ToList();

            _stockRepository.AtualizarDividendos(id, dividendos);

            //var preco = new StockPriceEntity(stockResult.)
            //_stockRepository.AtualizarPrecos(id, dividendos);

            return Ok("Pong");
        }
    }
}
