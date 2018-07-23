using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrqsTodo.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;
using CqrsTodo.Exceptions;

namespace CrqsTodo
{
    internal sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task Handle<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();

            if (handler == null) throw new CommandHandlerNotFoundException(typeof(TCommand));

            return handler.Handle(command);
        }
    }
}
