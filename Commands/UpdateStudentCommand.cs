using MediatR;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Commands {
    public record UpdateStudentCommand(int Id, UpdateStudentDto Dto) : IRequest<StudentDto>;

}
