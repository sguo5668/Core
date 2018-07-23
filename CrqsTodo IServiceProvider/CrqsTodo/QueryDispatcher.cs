using CqrsTodo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CrqsTodo.Interfaces;

namespace CrqsTodo
{
    internal sealed class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Handle<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult> where TResult : Task
        {
            if (query == null) throw new ArgumentNullException("query");

            var handler = _serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();

            if (handler == null) throw new QueryHandlerNotFoundException(typeof(TQuery));

            return handler.Handle(query);
        }
    }
}
 
