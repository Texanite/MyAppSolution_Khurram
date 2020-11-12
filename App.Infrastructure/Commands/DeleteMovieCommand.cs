using App.Infrastructure.AmbientState;
using App.Infrastructure.Commands.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Infrastructure.Commands
{
    public class DeleteMovieCommand : BaseCommand<bool>, IDeleteMovieCommand
    {
        public DeleteMovieCommand(IAppAmbientState ambientState) : base(ambientState) { }

        public int MovieId { get; set; }

        public override bool Execute()
        {
            var movieDataModel = (from movie in appAmbientState.DbContext.Movies
                                    .Include(x => x.MovieStats)
                                 select movie).FirstOrDefault();

            if (movieDataModel != null)
            {
                appAmbientState.DbContext.Movies.Remove(movieDataModel);
                var a = appAmbientState.DbContext.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
