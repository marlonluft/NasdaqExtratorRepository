using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NasdaqExtrator.Core.Constants;
using NasdaqExtrator.Core.Settings;
using System;

namespace NasdaqExtrator.API.Util
{
    public static class HttpClientBuilder
    {
        public static void ConfigurarHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var openWeatherSetting = configuration.GetSection("NasdaqAPI").Get<NasdaqAPISetting>();

            services.AddHttpClient(HttpClientNameConstant.NASDAQ_API, c =>
            {
                c.BaseAddress = new Uri(openWeatherSetting.URL);
            });
        }
    }
}
