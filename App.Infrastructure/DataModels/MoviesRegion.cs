using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DataModels
{
    public class MoviesRegion
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public Movie Movie { get; set; }
    }
}
