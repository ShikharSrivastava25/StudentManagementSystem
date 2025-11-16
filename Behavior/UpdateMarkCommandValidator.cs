using FluentValidation;
using StudentManagementSystem.Commands;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Behavior {
    public class UpdateMarkCommandValidator : AbstractValidator<UpdateMarkCommand> {
        public UpdateMarkCommandValidator(IValidator<UpdateMarkDto> dtoValidator) {
            RuleFor(x => x.Dto).NotNull().SetValidator(dtoValidator);
        }
    }

}
