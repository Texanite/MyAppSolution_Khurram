using App.Infrastructure.DataContexts;
using App.SharedKernel.Abstractions;
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.AmbientState
{
    public interface IAppAmbientState
    {
        ILifetimeScope AutofacContainer { get; }
        IMapper Mapper { get; }
        ILoggerService Logger { get; }
        MovieDbContext DbContext { get; }
       
    }
}
