using System;
using System.Collections.Generic;
using System.Linq;

namespace NasdaqExtrator.Core.Entity
{
    public class StockDataEntity
    {
        public StockDataEntity()
        {
            MediaAnual = new List<StockDataValueEntity>();
            MediaAtual = 0;
            Historico = new List<StockDataValueEntity>();
        }

        public List<StockDataValueEntity> MediaAnual { get; set; }
        public decimal MediaAtual { get; set; }
        public List<StockDataValueEntity> Historico { get; set; }

        internal void CalculateAverage()
        {
            var groupByYear = Historico.GroupBy(x => x.Date.ToUniversalTime().Year).ToList();

            var currentYear = groupByYear.FirstOrDefault(x => x.Key == DateTime.Now.Year);

            if (currentYear != null)
            {
                MediaAtual = currentYear.Sum(x => x.Value) / currentYear.Count();
            }

            foreach (var year in groupByYear)
            {
                if (MediaAnual.Any(x => x.Date.ToUniversalTime().Year == year.Key)) continue;

                var average = year.Sum(x => x.Value) / year.Count();
                var avgYear = new StockDataValueEntity(average, new DateTime(year.Key, 1, 1));

                MediaAnual.Add(avgYear);
            }
        }
    }
}
