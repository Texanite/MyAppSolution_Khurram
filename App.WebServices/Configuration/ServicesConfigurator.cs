using App.Infrastructure.DataContexts;
using App.SharedKernel.Abstractions;
using App.SharedKernel.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebServices.Configuration
{
    public static class ServicesConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            #region Configure Logging Services
             services.AddSingleton<ILoggerService, LoggerService>();
            #endregion

            #region Swagger
             services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new OpenApiInfo { Title = "Eagle Eyes APIs", Version = "V1" });
             });
            #endregion

            #region AutoMapper Configuration
             services.AddAutoMapper(typeof(Startup));
            #endregion

            #region DbContext - InMemory
            services.AddDbContext<MovieDbContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "Database"));
            #endregion

            #region Web API Controller Configuration
            services.AddControllers();
            #endregion

        }
    }
}
