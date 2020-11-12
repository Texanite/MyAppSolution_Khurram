using App.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Infrastructure.Queries.Abstraction
{
    public interface IGetMovieStatsQuery
    {
        IQueryable<MovieStatsReportDataView> Execute();
    }
}
