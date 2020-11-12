using App.Infrastructure.AmbientState;
using App.Infrastructure.Commands.Abstraction;
using App.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using App.Infrastructure.DataModels;

namespace App.Infrastructure.Commands
{
    public class CreateMoviesCommand : BaseCommand<int>, ICreateMoviesCommand
    {
        public CreateMoviesCommand(IAppAmbientState ambientState): base(ambientState)
        {

        }

        public MovieDto MovieDtos { get; set; }

        public override int Execute()
        {
            Movie movie = new Movie
            {
                Id = MovieDtos.MovieId,
                Duration = MovieDtos.Duration,
                Release = MovieDtos.Release
            };

            List<MoviesRegion> moviesRegions = new List<MoviesRegion>();
            List<MovieStats> moviesStats = new List<MovieStats>();

            foreach(var region in MovieDtos.MoviesRegion)
            {
                moviesRegions.Add(new MoviesRegion
                {
                    Id = region.Id,
                    MovieId = region.MovieId,
                    Title = region.Title,
                    Language = region.Language
                });
            }

            foreach(var stats in MovieDtos.MoviesStats)
            {
                moviesStats.Add(new MovieStats
                {
                    Id = stats.Id,
                    MovieId = stats.MovieId,
                    WatchDuration = stats.WatchDurationMS
                });
            }

            appAmbientState.DbContext.Movies.Add(movie);
            appAmbientState.DbContext.moviesRegions.AddRange(moviesRegions);
            appAmbientState.DbContext.MovieStats.AddRange(moviesStats);

            var recordId = appAmbientState.DbContext.SaveChanges();

            return recordId;
        }
    }
}
