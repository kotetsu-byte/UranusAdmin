using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class HomeworkValidator : AbstractValidator<HomeworkDto>
    {
        public HomeworkValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Deadline).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
