using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class LessonPostValidator : AbstractValidator<LessonPostDto>
    {
        public LessonPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
