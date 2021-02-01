using NasdaqExtrator.Core.Entity.Consolidado;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Service.Consolidado
{
    public class DividendosPagosAnoService : IDividendosPagosAnoService
    {
        public List<DividendosPagosAnoEntity> ListarMelhores(int ano, int quantidadeRegistros)
        {
            return new List<DividendosPagosAnoEntity>
            {
                new DividendosPagosAnoEntity("IBM", 0.10m, 1.20m, 12, ano),
                new DividendosPagosAnoEntity("IBM", 0.10m, 1.20m, 12, ano)
            };
        }
    }
}
