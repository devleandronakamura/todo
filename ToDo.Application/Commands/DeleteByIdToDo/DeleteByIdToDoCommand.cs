using MediatR;

namespace ToDo.Application.Commands.DeleteToDo
{
    public class DeleteByIdToDoCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
