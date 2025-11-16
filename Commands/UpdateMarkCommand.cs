using MediatR;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Commands {
    public record UpdateMarkCommand(int MarkId, UpdateMarkDto Dto) : IRequest<MarkDto>;
}
