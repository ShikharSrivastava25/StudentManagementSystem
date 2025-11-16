using MediatR;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Commands {
    public record CreateStudentCommand(CreateStudentDto dto) : IRequest<StudentDto>;
 }
