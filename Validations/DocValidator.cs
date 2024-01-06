using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class DocValidator : AbstractValidator<DocDto>
    {
        public DocValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(0);
            RuleFor(x => x.DocName).NotEmpty();
            RuleFor(x => x.DocContent).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
