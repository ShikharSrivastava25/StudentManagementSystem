using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Commands {
    public class DeleteMarkHandler(AppDbContext dbContext) : IRequestHandler<DeleteMarkCommand, bool> {

        private readonly AppDbContext _db = dbContext;

        public async Task<bool> Handle(DeleteMarkCommand request, CancellationToken cancellationToken) {
            var mark = await _db.Marks.FirstOrDefaultAsync(m => m.Id == request.MarkId);
            if (mark == null)
                return false;

            _db.Marks.Remove(mark);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
