using MediatR;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Commands {
    public record CreateMarkCommand(int StudentId, CreateMarkDto dto) : IRequest<MarkDto>;
}
