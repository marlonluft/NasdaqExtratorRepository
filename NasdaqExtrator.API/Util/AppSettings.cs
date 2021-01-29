using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NasdaqExtrator.Core.Settings;

namespace NasdaqExtrator.API.Util
{
    public static class AppSettings
    {
        public static void ConfigurarAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<NasdaqAPISetting>(configuration.GetSection("NasdaqAPI"));
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            services.AddOptions();
        }
    }
}
