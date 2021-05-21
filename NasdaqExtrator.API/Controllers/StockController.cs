using Microsoft.AspNetCore.Mvc;
using NasdaqExtrator.API.ViewModel;
using NasdaqExtrator.Core.Repository;
using System.Linq;

namespace NasdaqExtrator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _stockRepository.ListAll();

            return Ok(result.Select(x => new StockViewModel(x)).ToList());
        }
    }
}
