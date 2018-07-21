﻿using System;
using System.Collections.Generic;
using System.Threading;
using SimpleCQRS.Interfaces;

namespace SimpleCQRS
{
    public class FakeBus : ICommandSender, IEventPublisher
    {
        private readonly Dictionary<Type, List<Action<IEvent>>> _routes = new Dictionary<Type, List<Action<IEvent>>>();

        public void RegisterHandler<T>(Action<T> handler) where T : IEvent
		{
            List<Action<IEvent>> handlers;

            if(!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IEvent>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add((x => handler((T)x)));
        }

        public void Send<T>(T command) where T : Command
        {
            List<Action<IEvent>> handlers;

            if (_routes.TryGetValue(typeof(T), out handlers))
            {
                if (handlers.Count != 1) throw new InvalidOperationException("cannot send to more than one handler");
                handlers[0](command);
            }
            else
            {
                throw new InvalidOperationException("no handler registered");
            }
        }

        public void Publish<T>(T @event) where T : Event
        {
            List<Action<IEvent>> handlers;

            if (!_routes.TryGetValue(@event.GetType(), out handlers)) return;

            foreach(var handler in handlers)
            {
                //dispatch on thread pool for added awesomeness
                var handler1 = handler;
                ThreadPool.QueueUserWorkItem(x => handler1(@event));
            }
        }
    }



   
   
}
