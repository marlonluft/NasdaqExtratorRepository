using NasdaqExtrator.Core.Entity.Consolidado;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Service.Consolidado
{
    public class EvolucaoDividendosService : IEvolucaoDividendosService
    {
        public List<EvolucaoDividendosEntity> ListarMelhores(int quantidadeRegistros, int quantidadeAnos)
        {
            return new List<EvolucaoDividendosEntity>
            {
                new EvolucaoDividendosEntity("IBM", 6, new List<EvolucaoDividendosAnoEntity>{
                        new EvolucaoDividendosAnoEntity(2021, 0.10m),
                        new EvolucaoDividendosAnoEntity(2020, 0.12m),
                        new EvolucaoDividendosAnoEntity(2019, 0.11m)
                    })
            };
        }
    }
}
