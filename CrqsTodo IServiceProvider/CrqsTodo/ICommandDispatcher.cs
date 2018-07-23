using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo
{
    public interface ICommandDispatcher
    {
        Task Handle<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
