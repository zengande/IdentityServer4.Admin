﻿using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.BuildingBlock
{
    public static class SerilogExtensions
    {
        public static IWebHostBuilder UseSerilogLogger(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSerilog((webHostBuilderContext, loggerConfiguration) =>
            {
                loggerConfiguration
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .MinimumLevel.Override("System", LogEventLevel.Information)
                    .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
            });

            return webHostBuilder;
        }

        public static IWebHostBuilder UseSerilogLogger(this IWebHostBuilder webHostBuilder, Action<WebHostBuilderContext, LoggerConfiguration> config)
        {
            webHostBuilder.UseSerilog(config);

            return webHostBuilder;
        }
    }
}
