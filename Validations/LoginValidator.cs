using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(4);
        }
    }
}
