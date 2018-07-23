using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrqsTodo.Interfaces
{
    public interface IQuery<out TResult> where TResult : Task
    {
    }
}
