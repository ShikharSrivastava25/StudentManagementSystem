using MediatR;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Query {
    public record GetMarksByStudentIdQuery(int StudentId) : IRequest<List<MarkDto>>;
}
