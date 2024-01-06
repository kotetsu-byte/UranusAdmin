using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(4);
            RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(4);
        }
    }
}
