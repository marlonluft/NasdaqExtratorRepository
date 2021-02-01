using NasdaqExtrator.Core.Entity.Consolidado;

namespace NasdaqExtrator.Core.Repository.Consolidado
{
    public interface IDividendosPagosAnoRepository
    {
        void Gravar(DividendosPagosAnoEntity entity);
    }
}
