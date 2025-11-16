using AutoMapper;
using MediatR;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTO;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Commands {
    public class CreateStudentHandler(AppDbContext dbContext, IMapper mapper) : IRequestHandler<CreateStudentCommand, StudentDto> {

        private readonly AppDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken) {
            var student = _mapper.Map<Student>(request.dto);
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<StudentDto>(student);
        }
    }
}
