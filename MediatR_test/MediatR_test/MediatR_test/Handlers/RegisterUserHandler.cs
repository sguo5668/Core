using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatR_test.Commands;

namespace MediatR_test.Handlers
{

	//Command handlers (typical commandhandler is like:

	//public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
	//{
	//	private readonly ProductDatabase _database;
	//	private readonly IMediator _mediator;

	//	public AddProductCommandHandler(ProductDatabase database, IMediator mediator)
	//	{
	//		_database = database;
	//		_mediator = mediator;
	//	}

	//	public void Handle(AddProductCommand command)
	//	{
	//		// command validation
	//		// add product to database

	//		var @event = new ProductAddedEvent(product.Id, product.Name, product.CategoryId);
	//		_mediator.Publish(@event);
	//	}
	//}


	//Each event implements INotification interface from MediatR library. 
	//It allows publishing an event in MediatR pipeline, at the end of processing command in command handler.



	public class RegisterUserHandler : IRequestHandler<RegisterUser, bool>
	{


		public RegisterUserHandler() { }
		public bool Handle(RegisterUser message)
		{
			// save to database
			return true;
		}
	}
}
