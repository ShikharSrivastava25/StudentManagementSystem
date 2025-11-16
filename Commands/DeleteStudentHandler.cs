using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Commands {
    public class DeleteStudentHandler(AppDbContext dbContext) : IRequestHandler<DeleteStudentCommand, bool> {

        private readonly AppDbContext _db = dbContext;

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken) {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == request.Id);
            if (student == null)
                return false;

            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
