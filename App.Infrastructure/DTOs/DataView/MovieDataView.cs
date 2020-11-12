using App.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DTOs
{
    public class MovieDataView
    {
        public int Id { get; set; }
        public string Duration { get; set; }
        public int Release { get; set; }
        public ICollection<MovieStatsDataView> MovieStats { get; set; }
        public ICollection<MoviesRegionDataView> MoviesRegions { get; set; }
    }
}
