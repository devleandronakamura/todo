using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Application.Commands.UpdateByIdToDo
{
    public class UpdateByIdToDoCommandHandler : IRequestHandler<UpdateByIdToDoCommand, Unit>
    {
        private readonly ToDoDbContext _context;

        public UpdateByIdToDoCommandHandler(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateByIdToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = await _context.ToDo.SingleOrDefaultAsync(x => !x.Deleted && x.Id == request.Id);

            if (toDo is null)
                return Unit.Value;

            toDo.Update(request.Description, request.IsActive);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}