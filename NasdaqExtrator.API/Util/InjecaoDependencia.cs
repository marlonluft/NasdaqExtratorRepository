using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NasdaqExtrator.Core.External;
using NasdaqExtrator.Core.Repository;
using NasdaqExtrator.Core.Service;
using NasdaqExtrator.Core.Settings;

namespace NasdaqExtrator.API.Util
{
    public static class InjecaoDependencia
    {
        public static void RegistrarInjecaoDependencia(this IServiceCollection services)
        {
            // Service
            services.AddScoped<INasdaqAPIExternal, NasdaqAPIExternal>();
            services.AddScoped<IDividendHistoryService, DividendHistoryService>();
            services.AddScoped<IStockService, StockService>();

            // Repository
            services.AddScoped<IStockRepository, StockRepository>();

            // Setting
            services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }
    }
}
