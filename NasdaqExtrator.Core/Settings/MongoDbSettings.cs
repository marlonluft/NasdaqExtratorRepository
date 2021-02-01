namespace NasdaqExtrator.Core.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string StockCollectionName { get; set; }
        public string DividendHistoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string DividendosPagosAnoCollectionName { get; set; }
        public string EvolucaoDividendosCollectionName { get; set; }
        public string StockEvolucaoCollectionName { get; set; }
    }
}
