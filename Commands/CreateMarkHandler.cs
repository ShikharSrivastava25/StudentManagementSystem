using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTO;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Commands {
    public class CreateMarkHandler(AppDbContext dbContext, IMapper mapper) : IRequestHandler<CreateMarkCommand, MarkDto> {

        private readonly AppDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        public async Task<MarkDto> Handle(CreateMarkCommand request, CancellationToken cancellationToken) {
            var student = await _dbContext.Students
            .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

            if (student == null)
                throw new Exception($"Student with ID {request.StudentId} not found");

            // Map DTO to entity
            var mark = _mapper.Map<Mark>(request.dto);
            mark.StudentId = request.StudentId;

            _dbContext.Marks.Add(mark);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<MarkDto>(mark);
        }
    }
}
