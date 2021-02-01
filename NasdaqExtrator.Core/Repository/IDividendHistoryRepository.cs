using NasdaqExtrator.Core.Entity;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Repository
{
    public interface IDividendHistoryRepository
    {
        void Gravar(DividendHistoryEntity stock);
        List<DividendHistoryEntity> Listar(int anoConsolidar);
    }
}
