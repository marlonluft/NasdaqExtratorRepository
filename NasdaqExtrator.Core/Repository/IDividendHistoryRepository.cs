using NasdaqExtrator.Core.Entity;

namespace NasdaqExtrator.Core.Repository
{
    public interface IDividendHistoryRepository
    {
        void Gravar(DividendHistoryEntity stock);
    }
}
