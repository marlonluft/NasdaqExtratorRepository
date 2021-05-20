using Microsoft.AspNetCore.Mvc;
using NasdaqExtrator.Core.Repository;

namespace NasdaqExtrator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        public PingController(IStockRepository teste)
        {
            teste.ListAll();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Pong");
        }
    }
}
