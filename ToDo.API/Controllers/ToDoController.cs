using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Commands.CreateToDo;
using ToDo.Application.Commands.DeleteToDo;
using ToDo.Application.Commands.UpdateByIdToDo;
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

            return CreatedAtAction(nameof(GetById), new { Id = id }, command);
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
            var command = new DeleteByIdToDoCommand() { Id = id };

            var toDo = await _mediator.Send(command);

            return Ok(toDo);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateByIdToDoCommand input)
        {
            var command = new UpdateByIdToDoCommand() { Id = input.Id, Description = input.Description, IsActive = input.IsActive };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
