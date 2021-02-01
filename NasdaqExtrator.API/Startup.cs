using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using NasdaqExtrator.API.Util;
using NasdaqExtrator.Core.Service;
using System;
using System.IO;

namespace NasdaqExtrator.API
{
    public class Startup
    {
        private readonly string _mongoDB;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _mongoDB = Configuration["MongoDbSettings:ConnectionString"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.ConfigurarAppSettings(Configuration);
            services.ConfigurarHttpClient(Configuration);
            services.RegistrarInjecaoDependencia();

            ConfigurarHangFire(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            ConfigurarArquivosEstaticos(app);

            app.UseRouting();

            app.UseAuthorization();

            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            RegistrarJobsRecorrentes();
        }

        private void ConfigurarHangFire(IServiceCollection services)
        {
            var mongoUrlBuilder = new MongoUrlBuilder(_mongoDB);
            var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

            // Add Hangfire services. Hangfire.AspNetCore nuget required
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMongoStorage(mongoClient, mongoUrlBuilder.DatabaseName, new MongoStorageOptions
                {
                    MigrationOptions = new MongoMigrationOptions
                    {
                        MigrationStrategy = new MigrateMongoMigrationStrategy(),
                        BackupStrategy = new CollectionMongoBackupStrategy()
                    },
                    Prefix = "hangfire.NasdaqExtrator",
                    CheckConnection = true
                })
            );
            services.AddHangfireServer();
        }

        private void RegistrarJobsRecorrentes()
        {
            RecurringJob.AddOrUpdate<IDividendHistoryService>("ImportarHistorico", x => x.ImportarHistorico(DateTime.Now.AddDays(-1)), Cron.Daily);
        }

        private void ConfigurarArquivosEstaticos(IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
            });
        }
    }
}
