using FluentValidation;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Behavior {
    public class UpdateStudentDtoValidator : AbstractValidator<UpdateStudentDto> {
        public UpdateStudentDtoValidator() {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Age).InclusiveBetween(5, 100);
        }
    }
}
