using NasdaqExtrator.Core.Entity.Consolidado;
using NasdaqExtrator.Core.Repository.Consolidado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NasdaqExtrator.Core.Service.Consolidado
{
    public class DividendosPagosAnoService : IDividendosPagosAnoService
    {
        private readonly IDividendHistoryService _dividendHistoryService;
        private readonly IDividendosPagosAnoRepository _dividendosPagosAnoRepository;

        public DividendosPagosAnoService(IDividendHistoryService dividendHistoryService, IDividendosPagosAnoRepository dividendosPagosAnoRepository)
        {
            _dividendHistoryService = dividendHistoryService;
            _dividendosPagosAnoRepository = dividendosPagosAnoRepository;
        }

        public List<DividendosPagosAnoEntity> ListarMelhores(int ano, int quantidadeRegistros)
        {
            return _dividendosPagosAnoRepository.ListarValorTotalPagoDecrescente(ano, quantidadeRegistros);
        }

        public void Consolidar(int anoConsolidar)
        {
            var historicoDividendosImportados = _dividendHistoryService.Listar(anoConsolidar);

            var historicoConsolidadoPorSimbolo = historicoDividendosImportados
                .GroupBy(x => x.Simbolo)
                .Select(x =>
                {
                    var valorTotal = x.Sum(y => y.Valor);
                    var quantidadeTotal = x.Count();

                    return new DividendosPagosAnoEntity(x.First().Simbolo, valorTotal / quantidadeTotal, valorTotal, quantidadeTotal, anoConsolidar);
                }).ToList();

            _dividendosPagosAnoRepository.GravarLista(historicoConsolidadoPorSimbolo);
        }
    }
}
