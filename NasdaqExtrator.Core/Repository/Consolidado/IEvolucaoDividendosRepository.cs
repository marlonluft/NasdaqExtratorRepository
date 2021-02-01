using NasdaqExtrator.Core.Entity.Consolidado;

namespace NasdaqExtrator.Core.Repository.Consolidado
{
    public interface IEvolucaoDividendosRepository
    {
        void Gravar(EvolucaoDividendosEntity entity);
    }
}
