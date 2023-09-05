using MediatR;
using ToDo.Domain.Models;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Application.Commands.CreateToDo
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, Guid>
    {
        private readonly ToDoDbContext _context;

        public CreateToDoCommandHandler(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = new ToDoModel(request.Description);

            await _context.ToDo.AddAsync(toDo);
            await _context.SaveChangesAsync();

            return toDo.Id;
        }
    }
}