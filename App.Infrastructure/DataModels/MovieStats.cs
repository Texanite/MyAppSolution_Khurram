using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DataModels
{
    public class MovieStats
    {
        public MovieStats()
        {

        }

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int WatchDuration { get; set; }
        public Movie Movie { get; set; }
    }
}
