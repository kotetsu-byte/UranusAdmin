using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class UserPostValidator : AbstractValidator<UserPostDto>
    {
        public UserPostValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
