using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Commands {
    public class UpdateStudentHandler(AppDbContext dbContext, IMapper mapper) : IRequestHandler<UpdateStudentCommand, StudentDto> {

        private readonly AppDbContext _db = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<StudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken) {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == request.Id);

            if (student == null)
                throw new Exception($"Student with ID {request.Id} not found");

            _mapper.Map(request.Dto, student);
            await _db.SaveChangesAsync();

            return _mapper.Map<StudentDto>(student);
        }
    }
}
