using App.Domain.Entities;
using App.Domain.Entities.Abstractions;
using App.Infrastructure.AmbientState;
using App.Infrastructure.Commands;
using App.Infrastructure.Commands.Abstraction;
using App.Infrastructure.Queries;
using App.Infrastructure.Queries.Abstraction;
using App.Services.Abstractions;
using App.Services.AppServices;
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebServices.Configuration
{
    public class IoCConfigurator : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {

            //AutoMapper
            var Mapper = AutomapperConfigurator.Configuration();

            containerBuilder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve)).InstancePerLifetimeScope();

            containerBuilder.RegisterType<AppAmbientState>().As<IAppAmbientState>();

            //Services
            containerBuilder.RegisterType<MovieService>().As<IMovieServices>();
      
            //Entities
            containerBuilder.RegisterType<MovieEntity>().As<IMovieEntity>();

            //Queries
            containerBuilder.RegisterType<GetMoviesQuery>().As<IGetMoviesQuery>();
            containerBuilder.RegisterType<GetMovieByIdQuery>().As<IGetMovieByIdQuery>();
            containerBuilder.RegisterType<GetMovieStatsQuery>().As<IGetMovieStatsQuery>();

            //Commands
            containerBuilder.RegisterType<CreateMoviesCommand>().As<ICreateMoviesCommand>();       
            containerBuilder.RegisterType<DeleteMovieCommand>().As<IDeleteMovieCommand>();

        }
    }
}
