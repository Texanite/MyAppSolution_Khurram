using App.Domain.Entities.Abstractions;
using App.Infrastructure.AmbientState;
using App.Infrastructure.Commands.Abstraction;
using App.Infrastructure.DTOs;
using App.Infrastructure.Queries.Abstraction;
using Autofac;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Entities
{
    public class MovieEntity : IMovieEntity
    {
        private readonly IAppAmbientState appAmbientState;

        public MovieEntity(IAppAmbientState appAmbient)
        {
            this.appAmbientState = appAmbient;
        }

        public IQueryable<MovieDataView> GetMovies()
        {
            try
            {
                var query = this.appAmbientState.AutofacContainer.Resolve<IGetMoviesQuery>();
                var moviesDataModelList = query.Execute();
                var moviesDataViewList = appAmbientState.Mapper.Map<List<MovieDataView>>(moviesDataModelList).AsQueryable();

                return moviesDataViewList;
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
                throw;
            }
        }

        public IQueryable<MovieDataView> GetMovie(int movieId)
        {
            try
            {
                var query = this.appAmbientState.AutofacContainer.Resolve<IGetMovieByIdQuery>();
                query.MovieId = movieId;
                var movieDataModel = query.Execute();

                if (movieDataModel != null)
                {
                    var movieDataView = appAmbientState.Mapper.Map<List<MovieDataView>>(movieDataModel).AsQueryable();
                    return movieDataView;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw;
            }
        }

        public IQueryable<MovieStatsReportDataView> GetMovieStats()
        {
            try
            {
                var query = this.appAmbientState.AutofacContainer.Resolve<IGetMovieStatsQuery>();
                var moviesStatsData = query.Execute();

                return moviesStatsData;
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp);
                throw;
            }
        }

        public int CreateMovie(MovieDto movie)
        {
            try
            {
                var query = this.appAmbientState.AutofacContainer.Resolve<ICreateMoviesCommand>();
                query.MovieDtos = movie;
                var movieId = query.Execute();

                return movieId;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw;
            }
        }

        public bool DeleteMovie(int movieId)
        {
            try
            {
                var query = this.appAmbientState.AutofacContainer.Resolve<IDeleteMovieCommand>();
                query.MovieId = movieId;
                var isRecordDeleted = query.Execute();

                return isRecordDeleted; 
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw;
            }
        } 
    }
}
