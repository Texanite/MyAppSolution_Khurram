using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DTOs
{
    public class MovieStatsReportDataView
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public double AverageWatchDurations { get; set; }
        public int ReleaseYear { get; set; }
    }
}
