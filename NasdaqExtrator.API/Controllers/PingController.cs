using Microsoft.AspNetCore.Mvc;
using NasdaqExtrator.Core.Service;
using System;
using System.Threading.Tasks;

namespace NasdaqExtrator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly INasdaqAPIService _nasdaqApiService;

        public PingController(INasdaqAPIService nasdaqApiService)
        {
            _nasdaqApiService = nasdaqApiService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dividendsTask = _nasdaqApiService.GetDividends(DateTime.Now);
            var stockDividendsTask = _nasdaqApiService.GetStockDividends("IBM");
            var stockInfoTask = _nasdaqApiService.GetStockInfo("IBM");

            Task.WaitAll(dividendsTask, stockDividendsTask, stockInfoTask);

            return Ok("Pong");
        }
    }
}
