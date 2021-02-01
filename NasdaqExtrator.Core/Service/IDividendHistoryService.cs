using NasdaqExtrator.Core.Entity;
using System;
using System.Collections.Generic;

namespace NasdaqExtrator.Core.Service
{
    public interface IDividendHistoryService
    {
        void ImportarHistorico(DateTime data);
        List<DividendHistoryEntity> Listar(int anoConsolidar);
    }
}
