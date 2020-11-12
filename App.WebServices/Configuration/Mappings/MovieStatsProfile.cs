using App.Infrastructure.DataModels;
using App.Infrastructure.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebServices.Configuration.Mappings
{
    public class MovieStatsProfile : Profile
    {
        public MovieStatsProfile()
        {
            CreateMap<MovieStats, MovieStatsDataView>()
                .ReverseMap();
        }
    }
}
