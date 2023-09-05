using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Mappers;
using ToDo.Application.ViewModels;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Application.Queries.GetByIdToDo
{
    public class GetByIdToDoQueryHandle : IRequestHandler<GetByIdToDoQuery, ToDoViewModel>
    {
        private readonly ToDoDbContext _context;

        public GetByIdToDoQueryHandle(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoViewModel> Handle(GetByIdToDoQuery request, CancellationToken cancellationToken)
        {
            var toDoModel = await _context.ToDo.SingleOrDefaultAsync(x => !x.Deleted && x.Id == request.Id);

            return ToDoMapper.ToDoViewModel(toDoModel);
        }
    }
}
