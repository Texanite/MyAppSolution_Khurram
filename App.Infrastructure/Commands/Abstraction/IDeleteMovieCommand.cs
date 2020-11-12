using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Commands.Abstraction
{
    public interface IDeleteMovieCommand
    {
        int MovieId { get; set; }
        bool Execute();
    }
}
