using App.Infrastructure.AmbientState;
using App.Infrastructure.DTOs;
using App.Infrastructure.Queries.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Infrastructure.Queries
{
    public class GetMovieStatsQuery : BaseQuery<IQueryable<MovieStatsReportDataView>>, IGetMovieStatsQuery
    {
        public GetMovieStatsQuery(IAppAmbientState ambientState) : base(ambientState)
        {

        }

        public override IQueryable<MovieStatsReportDataView> Execute()
        {
            var movieDbContext = appAmbientState.DbContext;

            var groupMovieStatsData = 
                (from movie in movieDbContext.Movies.Include(x => x.MoviesRegions)
                 join movieStat in movieDbContext.MovieStats on movie.Id equals movieStat.MovieId into ms
                 from movieStats in ms.DefaultIfEmpty()
                 group new { movie, movieStats } by movie.Id into movieDataGrouped
                      select new
                         {
                            MovieId = movieDataGrouped.Key,
                            AverageWatch = movieDataGrouped.Select(x => x.movieStats).Average(x => x.WatchDuration),
                            NumberOfStatsAppearForMovie = movieDataGrouped.Select(x => x.movie).Count()
                         });

            var movieStatsReportData = 
                (from movie in movieDbContext.Movies
                       .Include(x => x.MoviesRegions)
                join movieStat in groupMovieStatsData on movie.Id equals movieStat.MovieId into mg
                from movieStatsData in mg.DefaultIfEmpty()
                select new MovieStatsReportDataView
                    {
                        MovieId = movie.Id,
                        Title = movie.MoviesRegions.Select(x => x.Title).FirstOrDefault(),
                        AverageWatchDurations = movieStatsData.AverageWatch,
                        ReleaseYear = movie.Release

                    }).OrderByDescending(x=>x.ReleaseYear);

            return movieStatsReportData;
        }

    }
}
