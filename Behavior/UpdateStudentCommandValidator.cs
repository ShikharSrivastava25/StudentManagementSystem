using FluentValidation;
using StudentManagementSystem.Commands;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Behavior {
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand> {
        public UpdateStudentCommandValidator(IValidator<UpdateStudentDto> dtoValidator) {
            RuleFor(x => x.Dto).NotNull().SetValidator(dtoValidator);
        }
    }
}
