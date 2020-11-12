using App.Infrastructure.DataContexts;
using App.Infrastructure.DataModels;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace App.Infrastructure.SeedData
{
    public class DataGenerator
    {
       
         public static void Initialize(IServiceProvider serviceProvider)
         {
             using (var context = new MovieDbContext(
                 serviceProvider.GetRequiredService<DbContextOptions<MovieDbContext>>()))
             {
                 if (context.Movies.Any<Movie>())
                 {
                     return; //Data has already seeded
                 }
                 else
                 {
                     var movies = new List<Movie>
                     {
                         new Movie
                         {
                             Id = 3,
                             Release = 2013,
                             Duration = "01:49:00"
                         },
                         new Movie
                         {
                             Id = 4,
                             Release = 2012,
                             Duration = "02:45:00"
                         },
                         new Movie
                         {
                             Id = 5,
                             Release = 2012,
                             Duration = "01:58:00"
                         },
                          new Movie
                         {
                             Id = 6,
                             Release = 2010,
                             Duration = "02:16:00"
                         },
                          new Movie
                         {
                             Id = 7,
                             Release = 2011,
                             Duration = "02:13:00"
                         }
                     };

                    var moviesRegion = new List<MoviesRegion>
                    {
                        new MoviesRegion
                        {
                            Id = 1,
                            MovieId = 3,
                            Title = "Elysium",
                            Language = "AR"
                        },
                        new MoviesRegion
                        {
                            Id = 2,
                            MovieId = 3,
                            Title = "ELYSIUM",
                            Language = "EN"
                        },
                        new MoviesRegion
                        {
                            Id = 4,
                            MovieId = 3,
                            Title = "Elysium",
                            Language = "HI"
                        },
                        new MoviesRegion
                        {
                            Id = 5,
                            MovieId = 3,
                            Title = "Elysium",
                            Language = "RU"
                        },
                        new MoviesRegion
                        {
                            Id = 6,
                            MovieId = 3,
                            Title = "Элизиум – Рай Не На Земле",
                            Language = "RU"
                        },
                        new MoviesRegion
                        {
                            Id = 7,
                            MovieId = 3,
                            Title = "Elysium",
                            Language = "JA"
                        },
                        new MoviesRegion
                        {
                            Id = 8,
                            MovieId = 3,
                            Title = "エリジウム",
                            Language = "JA"
                        },
                         new MoviesRegion
                        {
                            Id = 9,
                            MovieId = 4,
                            Title = "Django Unchained",
                            Language = "EN"
                        },
                          new MoviesRegion
                        {
                            Id = 10,
                            MovieId = 4,
                            Title = "Django Unchained",
                            Language = "RU"
                        },
                          new MoviesRegion
                        {
                            Id = 11,
                            MovieId = 4,
                            Title = "Django Unchained",
                            Language = "AR"
                        },
                          new MoviesRegion
                        {
                            Id = 12,
                            MovieId = 5,
                            Title = "TOTAL RECALL (2012)",
                            Language = "EN"
                        },
                          new MoviesRegion
                        {
                            Id = 13,
                            MovieId = 5,
                            Title = "توتال ريكول",
                            Language = "AR"
                        },
                          new MoviesRegion
                        {
                            Id = 14,
                            MovieId = 5,
                            Title = "Total Recall",
                            Language = "RU"
                        },
                          new MoviesRegion
                        {
                            Id = 15,
                            MovieId = 5,
                            Title = "Вспомнить Всё",
                            Language = "RU"
                        },
                          new MoviesRegion
                        {
                            Id = 16,
                            MovieId = 5,
                            Title = "トータル・リコール",
                            Language = "JA"
                        },
                           new MoviesRegion
                        {
                            Id = 17,
                            MovieId = 6,
                            Title = "The Amazing Spider-Man",
                            Language = "EU"
                        },
                            new MoviesRegion
                        {
                            Id = 18,
                            MovieId = 7,
                            Title = "Moneyball",
                            Language = "EU"
                        }
                    };


                    var movieStats = new List<MovieStats>
                    {
                        new MovieStats
                        {
                            Id = 1,
                            MovieId = 3,
                            WatchDuration = 5412842
                        },
                        new MovieStats
                        {
                            Id = 2,
                            MovieId = 3,
                            WatchDuration = 7107064
                        },
                        new MovieStats
                        {
                            Id = 3,
                            MovieId = 7,
                            WatchDuration = 1792718
                        },
                        new MovieStats
                        {
                            Id = 4,
                            MovieId = 4,
                            WatchDuration = 5205831
                        },
                        new MovieStats
                        {
                            Id = 5,
                            MovieId = 4,
                            WatchDuration = 4401395
                        },
                        new MovieStats
                        {
                            Id = 6,
                            MovieId = 5,
                            WatchDuration = 1721064
                        },
                        new MovieStats
                        {
                            Id = 7,
                            MovieId = 5,
                            WatchDuration = 5423305
                        },
                        new MovieStats
                        {
                            Id = 8,
                            MovieId = 5,
                            WatchDuration = 4858127
                        },
                         new MovieStats
                        {
                            Id = 9,
                            MovieId = 6,
                            WatchDuration = 3798374
                        },
                          new MovieStats
                        {
                            Id = 10,
                            MovieId = 6,
                            WatchDuration = 3186632
                        },
                           new MovieStats
                        {
                            Id = 11,
                            MovieId = 6,
                            WatchDuration = 3133097
                        },
                    };

                    context.Movies.AddRange(movies);
                    context.moviesRegions.AddRange(moviesRegion);
                    context.MovieStats.AddRange(movieStats);

                    context.SaveChanges();

                }
            }
        }
    }
}
