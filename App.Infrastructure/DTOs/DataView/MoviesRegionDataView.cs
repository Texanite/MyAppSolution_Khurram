using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DTOs
{
    public class MoviesRegionDataView
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
    }
}
