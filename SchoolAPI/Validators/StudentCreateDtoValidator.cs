using FluentValidation;
using SchoolAPI.DTOs;

namespace SchoolAPI.Validators
{
    public sealed class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email))
                .MaximumLength(255);
        }
    }
}
