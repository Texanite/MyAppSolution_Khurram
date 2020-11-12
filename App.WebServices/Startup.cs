using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.WebServices.Configuration;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace App.WebServices
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ContainerBuilder AutofacContainerBuilder { get; }
        public ILifetimeScope AutofacContainer { get; private set; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutofacContainerBuilder = new ContainerBuilder();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ServicesConfigurator.Configure(services, Configuration);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<IoCConfigurator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppConfigurator.Configure(app, env, AutofacContainer);
        }
    }
}
