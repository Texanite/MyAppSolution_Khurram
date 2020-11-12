using App.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Infrastructure.Queries.Abstraction
{
    public interface IGetMovieByIdQuery
    {
         int MovieId { get; set; }
        IQueryable<Movie> Execute();
    }
}
