using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Mappers;
using ToDo.Application.ViewModels;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Application.Queries.GetAllToDo
{
    public class GetAllToDoQueryHandler : IRequestHandler<GetAllToDoQuery, List<ToDoViewModel>>
    {
        private readonly ToDoDbContext _context;

        public GetAllToDoQueryHandler(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoViewModel>> Handle(GetAllToDoQuery request, CancellationToken cancellationToken)
        {
            var toDoList = await _context.ToDo.Where(x => !x.Deleted).ToListAsync();

            return ToDoMapper.ToDoViewModelList(toDoList);
        }
    }
}
