using CrqsTodo.DTO;
using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.Queries
{
    public class GetTodoById : IQuery<Task<Todo>>
    {
        public Guid Id { get; }

        public GetTodoById(Guid id)
        {
            Id = id;
        }
    }
}
