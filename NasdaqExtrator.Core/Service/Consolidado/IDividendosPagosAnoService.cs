using NasdaqExtrator.Core.Entity.Consolidado;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Service.Consolidado
{
    public interface IDividendosPagosAnoService
    {
        List<DividendosPagosAnoEntity> ListarMelhores(int ano, int quantidadeRegistros);
        void Consolidar(int anoConsolidar);
    }
}
