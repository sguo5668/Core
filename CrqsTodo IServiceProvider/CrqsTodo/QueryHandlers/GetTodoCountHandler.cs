using CrqsTodo.Interfaces;
using CrqsTodo.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.QueryHandlers
{
    internal sealed class GetTodoCountHandler : IQueryHandler<GetTodoCount, Task<int>>
    {
        private readonly TodoContext _context;

        public GetTodoCountHandler(TodoContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(GetTodoCount query)
        {
            return await _context.Todos.CountAsync();
        }
    }
}
