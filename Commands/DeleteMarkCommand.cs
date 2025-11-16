using MediatR;

namespace StudentManagementSystem.Commands {
    public record DeleteMarkCommand(int MarkId) : IRequest<bool>;
}
