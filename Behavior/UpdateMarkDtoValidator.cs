using FluentValidation;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Behavior {
    public class UpdateMarkDtoValidator : AbstractValidator<UpdateMarkDto> {
        public UpdateMarkDtoValidator() {
            RuleFor(x => x.Subject).NotEmpty();
            RuleFor(x => x.Score).InclusiveBetween(0, 100);
        }
    }
}
