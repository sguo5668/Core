﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.Interfaces
{
	public interface IRepository<T> where T : AggregateRoot, new()
	{
		void Save(AggregateRoot aggregate, int expectedVersion);
		T GetById(Guid id);
	}
}
