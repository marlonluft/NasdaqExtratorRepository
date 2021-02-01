﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NasdaqExtrator.Core.Repository;
using NasdaqExtrator.Core.Repository.Consolidado;
using NasdaqExtrator.Core.Service;
using NasdaqExtrator.Core.Service.Consolidado;
using NasdaqExtrator.Core.Settings;

namespace NasdaqExtrator.API.Util
{
    public static class InjecaoDependencia
    {
        public static void RegistrarInjecaoDependencia(this IServiceCollection services)
        {
            // Service
            services.AddScoped<INasdaqAPIService, NasdaqAPIService>();
            services.AddScoped<IDividendHistoryService, DividendHistoryService>();
            services.AddScoped<IDividendosPagosAnoService, DividendosPagosAnoService>();
            services.AddScoped<IEvolucaoDividendosService, EvolucaoDividendosService>();
            services.AddScoped<IStockEvolucaoService, StockEvolucaoService>();

            // Repository
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IDividendHistoryRepository, DividendHistoryRepository>();
            services.AddScoped<IDividendosPagosAnoRepository, DividendosPagosAnoRepository>();
            services.AddScoped<IEvolucaoDividendosRepository, EvolucaoDividendosRepository>();
            services.AddScoped<IStockEvolucaoRepository, StockEvolucaoRepository>();

            // Setting
            services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }
    }
}
