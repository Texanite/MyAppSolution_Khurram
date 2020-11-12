using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DTOs.DataConstruction
{
    public class MovieRegionDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
    }
}
