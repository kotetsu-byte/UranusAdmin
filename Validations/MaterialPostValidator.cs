﻿using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class MaterialPostValidator : AbstractValidator<MaterialPostDto>
    {
        public MaterialPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.MaterialName).NotEmpty();
            RuleFor(x => x.MaterialContent).NotEmpty();
            RuleFor(x => x.HomeworkId).NotEmpty().NotEqual(0);
            RuleFor(x => x.LessonId).NotEmpty().NotEqual(0);
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
