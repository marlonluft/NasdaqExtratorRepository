using NasdaqExtrator.Core.Entity;

namespace NasdaqExtrator.API.ViewModel
{
    public class StockViewModel
    {
        public StockViewModel(StockEntity entity)
        {
            Symbol = entity.Symbol;
            Name = entity.Name;
            PriceCurrentAverage = entity.Prices.MediaAtual;
            DividendsCurrentAverage = entity.Dividends.MediaAtual;
        }

        public string Symbol { get; private set; }
        public string Name { get; private set; }
        public decimal PriceCurrentAverage { get; private set; }
        public decimal DividendsCurrentAverage { get; private set; }
    }
}
