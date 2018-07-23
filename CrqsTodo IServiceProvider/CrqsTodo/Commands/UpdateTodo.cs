using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.Commands
{
    public class UpdateTodo : ICommand
    {
        public Guid Id { get; }
        public string Description { get; }

        public UpdateTodo(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
