using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class LessonValidator : AbstractValidator<LessonDto>
    {
        public LessonValidator() 
        { 
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
