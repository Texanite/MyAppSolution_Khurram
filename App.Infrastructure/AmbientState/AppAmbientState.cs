using System;
using System.Collections.Generic;
using System.Text;
using App.Infrastructure.DataContexts;
using App.SharedKernel.Abstractions;
using Autofac;
using AutoMapper;

namespace App.Infrastructure.AmbientState
{
    public class AppAmbientState : IAppAmbientState, IDisposable
    {
        public ILifetimeScope AutofacContainer { get; }
        public IMapper Mapper { get; }
        public ILoggerService Logger { get; }

        public MovieDbContext DbContext { get; }

        public AppAmbientState(
            ILifetimeScope scope,
            IMapper mapper,
            ILoggerService logger,
            MovieDbContext dbContext)
        {
            AutofacContainer = scope;
            Mapper = mapper;
            Logger = logger;
            DbContext = dbContext;
        }


        public void Dispose()
        {
            AutofacContainer?.Dispose();
        }
    }
}
