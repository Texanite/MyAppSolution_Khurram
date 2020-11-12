using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DTOs.DataConstruction
{
    public class MovieStatDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int WatchDurationMS { get; set; }
    }
}
