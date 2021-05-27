using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;
using ProcessSystem.DB;
using ProcessSystem.Middleware;
using Prometheus;
using SeedWork.DB;
using SeedWork.Token;

namespace ProcessSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _env = env;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<Startup> _logger;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            using var collector = PrometheusCollectorHelper.CreateCollector();

            services.AddControllers();
            services.AddConfigurationOptions(Configuration);
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddMvc().AddNewtonsoftJson();

            services.AddTransient<IToken, TokenImpl>();

            services.AddDbContext<ProcessContext> (
                options =>
                {
                    options.UseNpgsql(new ConnectionStringBuilder(Configuration.GetConnectionString("process")).GetPlainString(),
                        o =>
                           o.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null));
                    options
                        .LogTo(message => _logger.LogTrace(message))
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();

                },
                ServiceLifetime.Scoped);

            services.AddTransient<IRegisterRepository, RegisterRepository>();


            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddShopWindowAuthentication();

            services.AddEventHubHealthChecks(Configuration, _env.EnvironmentName);

            services.AddEventHubVersion();

            // Registers required services for health checks
            services.AddHealthChecksUI().AddInMemoryStorage(o =>
                o.LogTo(message => _logger.LogTrace(message))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ValidateConfigurationOptions();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "EventHub v1.0"));

            app.UseExceptionHandler("/error");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapStandardHealthChecks();
            });
            app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

            app.UseMetricServer();
        }
    }
}
