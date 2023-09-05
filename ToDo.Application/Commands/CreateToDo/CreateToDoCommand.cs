using MediatR;

namespace ToDo.Application.Commands.CreateToDo
{
    public class CreateToDoCommand : IRequest<Guid>
    {
        public string Description { get; set; }
    }
}