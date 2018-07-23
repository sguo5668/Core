using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.Interfaces
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult> where TResult : Task
    {
        TResult Handle(TQuery query);
    }
}
