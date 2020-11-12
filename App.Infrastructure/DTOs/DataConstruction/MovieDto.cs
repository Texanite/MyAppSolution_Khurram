using App.Infrastructure.DTOs.DataConstruction;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DTOs
{
    public class MovieDto
    {
        public int MovieId { get; set; }       
        public string Duration { get; set; }
        public int Release { get; set; }

        public List<MovieRegionDto> MoviesRegion { get; set; }
        public List<MovieStatDto> MoviesStats { get; set; }

    }
}
