using App.Domain.Entities.Abstractions;
using App.Infrastructure.DTOs;
using App.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Services.AppServices
{
    public class MovieService : IMovieServices
    {
        private readonly IMovieEntity movieEntity;

        public MovieService(IMovieEntity movieEntity)
        {
            this.movieEntity = movieEntity;
        }

        public IQueryable<MovieDataView> GetMovies()
        {
            var queryResult = this.movieEntity.GetMovies();
            return queryResult;
        }

        public IQueryable<MovieDataView> GetMovie(int movieId)
        {
            var queryResult = this.movieEntity.GetMovie(movieId);
            return queryResult;
        }

        public IQueryable<MovieStatsReportDataView> GetMovieStats()
        {
            var queryResult = this.movieEntity.GetMovieStats();
            return queryResult;
        }

        public int CreateMovie(MovieDto movie)
        {
            var queryResult = this.movieEntity.CreateMovie(movie);
            return queryResult;
        }

        public bool DeleteMovie(int movieId)
        {
            var queryResult = this.movieEntity.DeleteMovie(movieId);
            return queryResult;
        }

    }
}
