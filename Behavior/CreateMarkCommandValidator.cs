using FluentValidation;
using StudentManagementSystem.Commands;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Behavior {
    public class CreateMarkCommandValidator : AbstractValidator<CreateMarkCommand> {
        public CreateMarkCommandValidator(IValidator<CreateMarkDto> dtoValidator) {
            RuleFor(x => x.dto).NotNull().SetValidator(dtoValidator);
        }
    }
}