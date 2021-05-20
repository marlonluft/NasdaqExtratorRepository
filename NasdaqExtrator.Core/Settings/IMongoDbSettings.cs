namespace NasdaqExtrator.Core.Settings
{
    public interface IMongoDbSettings
    {
        string StockCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
