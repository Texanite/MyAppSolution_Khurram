using App.Infrastructure.AmbientState;
using App.Infrastructure.DataModels;
using App.Infrastructure.DTOs;
using App.Infrastructure.Queries.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Infrastructure.Queries
{
    public class GetMoviesQuery : BaseQuery<IQueryable<Movie>>, IGetMoviesQuery
    {
        public GetMoviesQuery(IAppAmbientState ambientState) : base(ambientState)
        {

        }

        public override IQueryable<Movie> Execute()
        {
            var movieDbContext = appAmbientState.DbContext;

            var movieDataModel = (from movie in movieDbContext.Movies
                                    .Include(x=>x.MovieStats)
                                    .Include(x=>x.MoviesRegions)
                                  select movie)
                                  .OrderByDescending(y=>y.Release);

            return movieDataModel;
        }
    }
}
