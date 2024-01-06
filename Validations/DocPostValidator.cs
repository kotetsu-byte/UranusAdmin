using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class DocPostValidator : AbstractValidator<DocPostDto>
    {
        public DocPostValidator()
        {
            RuleFor(x => x.DocName).NotEmpty();
            RuleFor(x => x.DocContent).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
