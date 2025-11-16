using FluentValidation;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Behavior {
    public class CreateStudentValidator : AbstractValidator<CreateStudentDto> {
        public CreateStudentValidator() {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Age).InclusiveBetween(5, 100);
        }
    }
}
