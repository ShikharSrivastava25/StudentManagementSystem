using MediatR;

namespace StudentManagementSystem.Commands {
    public record DeleteStudentCommand(int Id) : IRequest<bool>;
}
