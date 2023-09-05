using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Infrastructure.Persistence;

namespace ToDo.Application.Commands.DeleteToDo
{
    internal class DeleteByIdToDoCommandHandler : IRequestHandler<DeleteByIdToDoCommand, Unit>
    {
        private readonly ToDoDbContext _context;

        public DeleteByIdToDoCommandHandler(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteByIdToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = await _context.ToDo.SingleOrDefaultAsync(x => !x.Deleted && x.Id == request.Id);

            toDo.Delete();

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
