using NasdaqExtrator.Core.Entity.Consolidado;

namespace NasdaqExtrator.Core.Repository.Consolidado
{
    public interface IStockEvolucaoRepository
    {
        void Gravar(StockEvolucaoEntity entity);
    }
}
