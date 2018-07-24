using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client;
 
namespace RaBlog.Models
{
	public interface IDocumentStoreHolder
	{
		IDocumentStore Store { get; }
	}
}
