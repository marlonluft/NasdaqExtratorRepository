using NasdaqExtrator.Core.Entity.Consolidado;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Service.Consolidado
{
    public interface IStockEvolucaoService
    {
        List<StockEvolucaoEntity> ListarMelhores(int quantidadeRegistros, int quantidadeAnos);
        void Consolidar(int anoConsolidar);
    }
}
