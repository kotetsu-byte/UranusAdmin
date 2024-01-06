using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class VideoPostValidator : AbstractValidator<VideoPostDto>
    {
        public VideoPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.VideoName).NotEmpty();
            RuleFor(x => x.VideoContent).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
