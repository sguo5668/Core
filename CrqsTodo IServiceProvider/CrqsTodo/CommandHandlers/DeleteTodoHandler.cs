using CrqsTodo.Commands;
using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.CommandHandlers
{
    internal sealed class DeleteTodoHandler : ICommandHandler<DeleteTodo>
    {
        private readonly TodoContext _context;

        public DeleteTodoHandler(TodoContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteTodo command)
        {
            var todo = await _context.Todos.FindAsync(command.Id);

            if (todo != null)
            {
                _context.Todos.Remove(todo);

                await _context.SaveChangesAsync();
            }
        }
    }
}
