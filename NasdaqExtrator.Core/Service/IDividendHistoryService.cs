using System;

namespace NasdaqExtrator.Core.Service
{
    public interface IDividendHistoryService
    {
        void ImportarHistorico(DateTime data);
    }
}
