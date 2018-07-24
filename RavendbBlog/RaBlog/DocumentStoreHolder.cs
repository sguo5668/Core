using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RaBlog.Models;
using Raven.Client;
using Raven.Client.Document;

namespace RaBlog
{
	public class DocumentStoreHolder : IDocumentStoreHolder
	{
		public DocumentStoreHolder(IOptions<RavenSettings> ravenSettings)
		{
			var settings = ravenSettings.Value;

			Store = new DocumentStore
			{
				//Url = settings.Url,
				//DefaultDatabase = settings.DefaultDatabase

				Url = "http://localhost:8080",
				DefaultDatabase = "MyDatabase"

			}.Initialize();
		}

		public IDocumentStore Store { get; }
	}
}
