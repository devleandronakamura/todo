using MediatR;

namespace ToDo.Application.Commands.UpdateByIdToDo
{
    public class UpdateByIdToDoCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}