using System;
using Serilog;

namespace Common.Helpers
{
    public static class LoggerHelper
    {

        public static void ConfigureLogging(ref LoggerConfiguration loggerConfiguration, string configName = "appsettings", string basePath = null)
        {
            loggerConfiguration
                .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                .Enrich.FromLogContext();

        }

    }
}
