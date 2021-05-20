namespace NasdaqExtrator.Core.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string StockCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
