using CrqsTodo.DTO;
using CrqsTodo.Interfaces;
using CrqsTodo.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrqsTodo.Interfaces;

namespace CrqsTodo.QueryHandlers
{
    internal sealed class GetAllTodoHandler : IQueryHandler<GetAllTodo, Task<IEnumerable<Todo>>>
    {
        private readonly TodoContext _context;

        public GetAllTodoHandler(TodoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Todo>> Handle(GetAllTodo query)
        {
            return await _context.Todos.ToListAsync();
        }
    }
}
