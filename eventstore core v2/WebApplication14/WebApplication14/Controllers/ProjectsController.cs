using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication14.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
	 	 private readonly IRepository _repository;

		private readonly IEventStoreConnection _connection;

		public ProjectsController(IEventStoreConnection connection, IRepository repository)
		{
			_connection = connection;
			_repository = repository;
		}

		[Route("{id}")]
		public Project Get(int id)
		{
			return new Project { id = Guid.NewGuid(), name = "Heart Beat" };
		}

		[Route(""), HttpPost]
		public Guid Add([FromBody]AddProjectReq req)
		{
			var id = Guid.NewGuid();
			var e = new ProjectAdded
			{
				Id = id,
				Name = req.Name
			};
		 	_repository.Save(id, _connection, new[] { e });
			return id;
		}

		//[Route("{id}/pm"), HttpPost]
		//public void AssignPm(Guid id, AssignPmToProjectReq req)
		//{
		//	var e = new PmToProjectAssigned
		//	{
		//		Id = id,
		//		PmId = req.StaffId
		//	};
		//	_repository.Save(id, new[] { e });
		//}
	}
}
