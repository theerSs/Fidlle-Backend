using Fidlle.Application.DTO;
using FluentValidation;

namespace Fidlle.Application.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {

            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Username).NotEmpty().MaximumLength(50).WithMessage("Username cannot be longer than 50 characters.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
            
    }
}
