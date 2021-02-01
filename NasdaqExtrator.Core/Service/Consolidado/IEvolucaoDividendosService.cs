using NasdaqExtrator.Core.Entity.Consolidado;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Service.Consolidado
{
    public interface IEvolucaoDividendosService
    {
        List<EvolucaoDividendosEntity> ListarMelhores(int quantidadeRegistros, int quantidadeAnos);
    }
}
