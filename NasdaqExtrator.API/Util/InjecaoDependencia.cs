using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
            services.AddScoped<INasdaqAPIService, NasdaqAPIService>();

            // Setting
            services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }
    }
}
