using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;
using NLog;
using NLog.Config;
using NLog.Web;
using App.SharedKernel;
using App.SharedKernel.Services;
using Microsoft.Extensions.DependencyInjection;
using App.Infrastructure.SeedData;
using App.Infrastructure.DataContexts;

namespace App.WebServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<MovieDbContext>();
                DataGenerator.Initialize(services);
            }

            var logger = NLog.LogManager.Setup()
               .SetupExtensions(s => s.AutoLoadAssemblies(false).RegisterLayoutRenderer("default-template", typeof(DefaultLoggingTemplate)))
               .RegisterNLogWeb()
               .LoadConfigurationFromFile("nlog.config")
               .GetCurrentClassLogger();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
              .UseNLog();
    }
}
