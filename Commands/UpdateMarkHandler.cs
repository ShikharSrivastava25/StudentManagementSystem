using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Commands {
    public class UpdateMarkHandler(AppDbContext dbContext, IMapper mapper) : IRequestHandler<UpdateMarkCommand, MarkDto> {

        private readonly AppDbContext _db = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<MarkDto> Handle(UpdateMarkCommand request, CancellationToken cancellationToken) {
            var mark = await _db.Marks.FirstOrDefaultAsync(m => m.Id == request.MarkId);
            if (mark == null)
                throw new Exception($"Mark with ID {request.MarkId} not found");

            _mapper.Map(request.Dto, mark);
            await _db.SaveChangesAsync();

            return _mapper.Map<MarkDto>(mark);
        }
    }
}
