using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DTOs
{
    public class ResultDto
    {
        public bool Ok { get; set; }
        public dynamic Data { get; set; }
        public string Error { get; set; }
    }
}
