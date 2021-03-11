using NasdaqExtrator.Core.Entity.Consolidado;
using NasdaqExtrator.Core.Repository.Consolidado;
using System.Collections.Generic;
using System.Linq;

namespace NasdaqExtrator.Core.Service.Consolidado
{
    public class EvolucaoDividendosService : IEvolucaoDividendosService
    {
        private readonly IDividendHistoryService _dividendHistoryService;
        private readonly IEvolucaoDividendosRepository _evolucaoDividendosRepository;

        public EvolucaoDividendosService(IDividendHistoryService dividendHistoryService, IEvolucaoDividendosRepository evolucaoDividendosRepository)
        {
            _dividendHistoryService = dividendHistoryService;
            _evolucaoDividendosRepository = evolucaoDividendosRepository;
        }

        public List<EvolucaoDividendosEntity> ListarMelhores(int quantidadeRegistros, int quantidadeAnos)
        {
            //TODO: limitar anos
            return _evolucaoDividendosRepository.ListarEstaveisDecrescente(quantidadeRegistros);
        }

        public void Consolidar(int anoConsolidar)
        {
            var historicoDividendosImportados = _dividendHistoryService.Listar(anoConsolidar);

            var historicoConsolidadoPorSimbolo = historicoDividendosImportados
                .GroupBy(x => x.Simbolo)
                .Select(x =>
                {
                    var quantidadeMediaDividendosPagos = 0;

                    var anos = x.GroupBy(y => y.DataPagamento.ToUniversalTime().Year).Select(y =>
                    {

                        var qtdDividendos = y.Count();
                        quantidadeMediaDividendosPagos += qtdDividendos;

                        return new EvolucaoDividendosAnoEntity(y.Key, y.Sum(p => p.Valor) / qtdDividendos);
                    }).ToList();

                    quantidadeMediaDividendosPagos /= anos.Count();

                    return new EvolucaoDividendosEntity(x.First().Simbolo, quantidadeMediaDividendosPagos, anos);
                }).ToList();

            _evolucaoDividendosRepository.GravarLista(historicoConsolidadoPorSimbolo);
        }
    }
}
