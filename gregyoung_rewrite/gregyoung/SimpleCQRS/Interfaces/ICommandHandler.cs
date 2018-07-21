using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.Interfaces
{
	public interface ICommandHandler<T>
	{
		void Handle(T message);
	}
}
