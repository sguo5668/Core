
using CrqsTodo;
using CrqsTodo.Commands;
using CrqsTodo.DTO;
using CrqsTodo.Queries;
using Microsoft.AspNetCore.Mvc;
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsTodo.Controllers
{
   // [ValidateModel]
    [Route("api/v1/[controller]")]
    public class ToDoController : Controller
    {
      //  private readonly IHubContext<Notifier> _notifier;
        private readonly ICommandDispatcher _command;
        private readonly IQueryDispatcher _query;

        public ToDoController(
           // IHubContext<Notifier> notifier,
             ICommandDispatcher command
             , IQueryDispatcher query
            )
        {
          //  _notifier = notifier;
            _command = command;
             _query = query;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _query.Handle<GetAllTodo, Task<IEnumerable<Todo>>>(new GetAllTodo()));
        }

        [HttpGet("{id}")]
        //[ValidateTodoExists]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _query.Handle<GetTodoById, Task<Todo>>(new GetTodoById(id)));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Todo value)
        {
            value.Id = Guid.NewGuid();

            var command = new CreateTodo(value.Id, value.Description);

            await _command.Handle(command);
           // return Ok();
            return Ok(await _query.Handle<GetTodoById, Task<Todo>>(new GetTodoById(value.Id)));
        }

        [HttpPost("{id}/[action]")]
        //[ValidateTodoExists]
        public async Task<IActionResult> MakeComplete(Guid id)
        {
            await _command.Handle(new MakeComplete(id));

            var todo = await _query.Handle<GetTodoById, Task<Todo>>(new GetTodoById(id));

          //  await _notifier.Clients.All.InvokeAsync("Notify", todo.Description + " is complete");

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Count()
        {
            return Ok(await _query.Handle<GetTodoCount, Task<int>>(new GetTodoCount()));
        }

        //// PUT api/values/5
        [HttpPut("{id}")]
        //[ValidateTodoExists]
        public async Task<IActionResult> Put(Guid id, [FromBody]Todo value)
        {
            await _command.Handle(new UpdateTodo(id, value.Description));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _command.Handle(new DeleteTodo(id));

            return Ok();
        }
    }
}
