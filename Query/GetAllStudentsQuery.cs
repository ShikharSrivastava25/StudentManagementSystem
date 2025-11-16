using MediatR;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Query {
    public record GetAllStudentsQuery() : IRequest<IEnumerable<StudentDto>>;
}
