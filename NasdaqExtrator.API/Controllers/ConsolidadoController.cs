using Microsoft.AspNetCore.Mvc;
using NasdaqExtrator.Core.Service.Consolidado;
using System;

namespace NasdaqExtrator.API.Controllers
{
    [Route("Consolidado")]
    public class ConsolidadoController : Controller
    {
        private readonly IDividendosPagosAnoService _dividendosPagosAnoService;
        private readonly IEvolucaoDividendosService _evolucaoDividendosService;
        private readonly IStockEvolucaoService _stockEvolucaoService;

        public ConsolidadoController(
            IDividendosPagosAnoService dividendosPagosAnoService,
            IEvolucaoDividendosService evolucaoDividendosService,
            IStockEvolucaoService stockEvolucaoService)
        {
            _dividendosPagosAnoService = dividendosPagosAnoService;
            _evolucaoDividendosService = evolucaoDividendosService;
            _stockEvolucaoService = stockEvolucaoService;
        }

        [HttpGet()]
        [Route("TopDividendoPagosAnoCorrente")]
        public IActionResult TopDividendoPagosAnoCorrente()
        {
            var topPagadoraDividendosCorrente = _dividendosPagosAnoService.ListarMelhores(DateTime.Now.Year, 10);

            return Ok(topPagadoraDividendosCorrente);
        }

        [HttpGet()]
        [Route("TopPagadorasDividendosEstaveis")]
        public IActionResult TopPagadorasDividendosEstaveis()
        {
            var topEvolucoesDividendos = _evolucaoDividendosService.ListarMelhores(10, 4);

            return Ok(topEvolucoesDividendos);
        }

        [HttpGet()]
        [Route("TopStocksCrescentes")]
        public IActionResult TopStocksCrescentes()
        {
            var topEvolucoesStock = _stockEvolucaoService.ListarMelhores(10, 4);

            return Ok(topEvolucoesStock);
        }
    }
}
