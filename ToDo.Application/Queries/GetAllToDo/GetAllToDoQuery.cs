using MediatR;
using ToDo.Application.ViewModels;

namespace ToDo.Application.Queries.GetAllToDo
{
    public class GetAllToDoQuery : IRequest<List<ToDoViewModel>>
    {
    }
}
