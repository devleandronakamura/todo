using MediatR;
using ToDo.Application.ViewModels;

namespace ToDo.Application.Queries.GetByIdToDo
{
    public class GetByIdToDoQuery : IRequest<ToDoViewModel>
    {
        public Guid Id { get; set; }
    }
}