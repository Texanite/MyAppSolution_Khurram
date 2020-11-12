using App.Infrastructure.AmbientState;
using App.Infrastructure.DataContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Commands.Abstraction
{
    public abstract class BaseCommand<T>
    {
        protected IAppAmbientState appAmbientState { get; }

        public BaseCommand(IAppAmbientState ambientState)
        {
            this.appAmbientState = ambientState;
        }

        public abstract T Execute();
    }
}
