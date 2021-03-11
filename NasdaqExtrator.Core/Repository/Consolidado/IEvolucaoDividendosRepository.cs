using NasdaqExtrator.Core.Entity.Consolidado;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Repository.Consolidado
{
    public interface IEvolucaoDividendosRepository
    {
        void GravarLista(List<EvolucaoDividendosEntity> lista);
        List<EvolucaoDividendosEntity> ListarEstaveisDecrescente(int quantidadeRegistros);
    }
}
