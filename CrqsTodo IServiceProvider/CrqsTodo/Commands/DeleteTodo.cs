using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.Commands
{
    public class DeleteTodo : ICommand
    {
        public Guid Id { get; }

        public DeleteTodo(Guid id)
        {
            Id = id;
        }
    }
}
