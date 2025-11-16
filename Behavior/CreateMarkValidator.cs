using FluentValidation;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Behavior {
    public class CreateMarkValidator : AbstractValidator<CreateMarkDto> {
        public CreateMarkValidator() {
            RuleFor(x => x.Subject).NotEmpty();
            RuleFor(x => x.Score).InclusiveBetween(0, 100);
        }
    }
}
