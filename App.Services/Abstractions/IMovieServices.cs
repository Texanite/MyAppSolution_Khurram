using App.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Services.Abstractions
{
    public interface IMovieServices
    {
        int CreateMovie(MovieDto movie);
        IQueryable<MovieDataView> GetMovies();
        IQueryable<MovieDataView> GetMovie(int movieId);
        IQueryable<MovieStatsReportDataView> GetMovieStats();
        bool DeleteMovie(int movieId);
    }
}
