using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrqsTodo.Interfaces;
using CrqsTodo.Commands;
using CrqsTodo.DTO;
using CrqsTodo;

namespace CqrsTodo.CommandHandlers
{
    internal sealed class MakeCompleteHandler : ICommandHandler<MakeComplete>
    {
        private readonly TodoContext _context;

        public MakeCompleteHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task Handle(MakeComplete command)
        {
            var todo = await _context.Todos.FindAsync(command.Id);

            todo.IsComplete = true;

            await _context.SaveChangesAsync();
        }
    }
}

