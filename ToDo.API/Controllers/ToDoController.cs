using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Commands.CreateToDo;
using ToDo.Application.Commands.DeleteToDo;
using ToDo.Application.Queries.GetAllToDo;
using ToDo.Application.Queries.GetByIdToDo;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateToDoCommand command)
        {
            var id = await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllToDoQuery();

            var toDoList = await _mediator.Send(query);

            return Ok(toDoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdToDoQuery() { Id = id };

            var toDo = await _mediator.Send(query);

            return Ok(toDo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var query = new DeleteByIdToDoCommand() { Id = id };

            var toDo = await _mediator.Send(query);

            return Ok(toDo);
        }
    }
}
