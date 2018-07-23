using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.Queries
{
    public class GetTodoCount : IQuery<Task<int>>
    {
    }
}
