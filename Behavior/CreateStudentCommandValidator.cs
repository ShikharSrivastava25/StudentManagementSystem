using FluentValidation;
using StudentManagementSystem.Commands;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Behavior {
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand> {
        public CreateStudentCommandValidator(IValidator<CreateStudentDto> dtoValidator) {
            RuleFor(x => x.dto).NotNull().SetValidator(dtoValidator);
        }
    }
}