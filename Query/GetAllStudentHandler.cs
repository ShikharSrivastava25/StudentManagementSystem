using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Query {
    public class GetAllStudentHandler(AppDbContext dbContext, IMapper mapper) : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>> {

        private readonly AppDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken) {
            var students = await _dbContext.Students.Include(s => s.Marks).ToListAsync(cancellationToken);

            return _mapper.Map<List<StudentDto>>(students);
        }
    }
}
