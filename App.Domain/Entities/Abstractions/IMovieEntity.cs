using App.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Entities.Abstractions
{
    public interface IMovieEntity
    {
        int CreateMovie(MovieDto movie);
        IQueryable<MovieDataView> GetMovies(); // All Movies
        IQueryable<MovieDataView> GetMovie(int movieId); //Movies with same Id
        IQueryable<MovieStatsReportDataView> GetMovieStats();
        bool DeleteMovie(int movieId);
    }
}
