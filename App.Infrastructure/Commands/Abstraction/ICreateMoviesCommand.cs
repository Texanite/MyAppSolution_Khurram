using App.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Commands.Abstraction
{
    public interface ICreateMoviesCommand
    {
        MovieDto MovieDtos { get; set; }
        int Execute();
    }
}
