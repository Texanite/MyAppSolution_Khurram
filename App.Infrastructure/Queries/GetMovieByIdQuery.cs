using App.Infrastructure.AmbientState;
using App.Infrastructure.DataModels;
using App.Infrastructure.DTOs;
using App.Infrastructure.Queries.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Queries
{
   

    public class GetMovieByIdQuery : BaseQuery<IQueryable<Movie>>, IGetMovieByIdQuery
    {
        public GetMovieByIdQuery(IAppAmbientState ambientState) : base(ambientState)
        {

        }

        public int MovieId { get; set; }

        public override IQueryable<Movie> Execute()
        {
            var movieDbContext = appAmbientState.DbContext;

            var movieDataModel = (from movie in movieDbContext.Movies
                                    .Include(x => x.MovieStats)
                                    .Include(x => x.MoviesRegions)
                                 where movie.Id == MovieId 
                                 select movie);

            if (movieDataModel.SelectMany(x=>x.MoviesRegions).Count() > 1)
            {
                return movieDataModel;
            }

            return null;
        }
    }
}
