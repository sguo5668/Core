using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventSourcing.Contracts.Events;


namespace WebApplication14
{
	public interface IRepository
	{
		void Save(Guid id, IEnumerable<IEvent> events);
	}
}
