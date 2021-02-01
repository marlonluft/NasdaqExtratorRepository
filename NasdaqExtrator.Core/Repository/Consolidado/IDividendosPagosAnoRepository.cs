using NasdaqExtrator.Core.Entity.Consolidado;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Repository.Consolidado
{
    public interface IDividendosPagosAnoRepository
    {
        void GravarLista(List<DividendosPagosAnoEntity> entities);
        List<DividendosPagosAnoEntity> ListarValorTotalPagoDecrescente(int ano, int quantidadeRegistros);
    }
}
