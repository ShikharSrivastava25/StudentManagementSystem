using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Query {
    public class GetMarksByStudentIdHandler(AppDbContext dbContext, IMapper mapper) : IRequestHandler<GetMarksByStudentIdQuery, List<MarkDto>> {

        private readonly AppDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        public async Task<List<MarkDto>> Handle(GetMarksByStudentIdQuery request, CancellationToken cancellationToken) {
            var marks = await _dbContext.Marks
            .Where(m => m.StudentId == request.StudentId)
            .ToListAsync(cancellationToken);

            return _mapper.Map<List<MarkDto>>(marks);
        }
    }
}
