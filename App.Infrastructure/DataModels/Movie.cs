using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DataModels
{
    public class Movie
    {
        public Movie()
        {
            this.MovieStats = new HashSet<MovieStats>();
            this.MoviesRegions = new HashSet<MoviesRegion>();
        }

        public int Id { get; set; }
        public string Duration { get; set; }
        public int Release  { get; set; }

        public ICollection<MovieStats> MovieStats { get; set; }
        public ICollection<MoviesRegion> MoviesRegions { get; set; }

    }
}
