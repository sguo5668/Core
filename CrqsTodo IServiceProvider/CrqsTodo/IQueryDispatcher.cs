using CrqsTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo
{
    public interface IQueryDispatcher
    {
        TResult Handle<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult> where TResult : Task;
    }
}
