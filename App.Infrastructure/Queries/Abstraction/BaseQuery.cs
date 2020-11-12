using App.Infrastructure.AmbientState;
using App.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Queries.Abstraction
{
    public abstract class BaseQuery<TResult> where TResult : class
    {
        //protected MovieDbContext movieDbContext;
        

        protected IAppAmbientState appAmbientState { get; }

        public BaseQuery(IAppAmbientState ambientState)
        {

            this.appAmbientState = ambientState;
            //this.movieDbContext = new MovieDbContext();
        }

        public abstract TResult Execute();

    }
}
