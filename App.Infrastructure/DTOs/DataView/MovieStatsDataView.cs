using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DTOs
{
    public class MovieStatsDataView
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int WatchDurationMS { get; set; }
    }
}
