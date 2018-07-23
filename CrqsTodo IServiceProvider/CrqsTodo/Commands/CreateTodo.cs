using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.Commands
{
    internal sealed class CreateTodo : ICommand
    {
        public Guid Id { get; }
        public string Description { get; }

        public CreateTodo(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
