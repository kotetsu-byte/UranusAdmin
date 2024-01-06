using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
