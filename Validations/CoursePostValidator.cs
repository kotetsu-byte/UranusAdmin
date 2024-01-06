using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class CoursePostValidator : AbstractValidator<CoursePostDto>
    {
        public CoursePostValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
