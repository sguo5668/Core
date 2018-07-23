using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.Commands
{
    public class MakeComplete : ICommand
    {
        public Guid Id { get; }

        public MakeComplete(Guid id)
        {
            Id = id;
        }
    }
}
