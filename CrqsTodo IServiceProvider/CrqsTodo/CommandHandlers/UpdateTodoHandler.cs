
using CrqsTodo;
using CrqsTodo.Commands;
using CrqsTodo.Interfaces;
using System.Threading.Tasks;

namespace CqrsTodo.CommandHandlers
{
    internal sealed class UpdateTodoHandler : ICommandHandler<UpdateTodo>
    {
        private readonly TodoContext _context;

        public UpdateTodoHandler(TodoContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateTodo command)
        {
            var todo = await _context.Todos.FindAsync(command.Id);

            todo.Description = command.Description;

            await _context.SaveChangesAsync();
        }
    }
}
