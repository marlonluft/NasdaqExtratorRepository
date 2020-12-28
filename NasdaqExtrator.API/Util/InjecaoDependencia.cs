using Microsoft.Extensions.DependencyInjection;
using NasdaqExtrator.Core.Service;

namespace NasdaqExtrator.API.Util
{
    public static class InjecaoDependencia
    {
        public static void RegistrarInjecaoDependencia(this IServiceCollection services)
        {
            // Service
            services.AddScoped<INasdaqAPIService, NasdaqAPIService>();
        }
    }
}
