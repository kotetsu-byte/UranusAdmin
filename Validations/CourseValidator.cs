using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class CourseValidator : AbstractValidator<CourseDto>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
