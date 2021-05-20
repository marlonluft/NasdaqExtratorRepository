using System;
using System.Threading.Tasks;
using Calendar = NasdaqExtrator.Core.DTO.Calendar;
using Dividends = NasdaqExtrator.Core.DTO.Quote.Dividends;
using Info = NasdaqExtrator.Core.DTO.Quote.Info;

namespace NasdaqExtrator.Core.External
{
    public interface INasdaqAPIExternal
    {
        Task<Calendar.DividendsDTO> GetDividends(DateTime date);
        Task<Info.InfoDTO> GetStockInfo(string stock);
        Task<Dividends.QuoteDividendsDTO> GetStockDividends(string stock);
    }
}
