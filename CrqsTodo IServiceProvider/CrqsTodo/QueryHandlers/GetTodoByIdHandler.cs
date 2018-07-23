using CrqsTodo.DTO;
using CrqsTodo.Interfaces;
using CrqsTodo.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.QueryHandlers
{
    internal sealed class GetTodoByIdHandler : IQueryHandler<GetTodoById, Task<Todo>>
    {
        private readonly TodoContext _context;

        public GetTodoByIdHandler(TodoContext context)
        {
            _context = context;
        }
        public async Task<Todo> Handle(GetTodoById query)
        {
            return await _context.Todos.FindAsync(query.Id);
        }
    }
}
