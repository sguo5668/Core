using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrqsTodo.Interfaces;
using CrqsTodo.Commands;
using CrqsTodo.DTO;

namespace CrqsTodo.CommandHandlers
{
    internal sealed class CreateTodoHandler : ICommandHandler<CreateTodo>
    {
        private readonly TodoContext _context;

        public CreateTodoHandler(TodoContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateTodo command)
        {
            _context.Todos.Add(new Todo
            {
                Id = command.Id,
                Description = command.Description,
                IsComplete = false
            });

            await _context.SaveChangesAsync();
        }
    }
}
