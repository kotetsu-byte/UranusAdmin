﻿using FluentValidation;
using UranusAdmin.Dto;

namespace UranusAdmin.Validations
{
    public class TestPostValidator : AbstractValidator<TestPostDto>
    {
        public TestPostValidator()
        {
            RuleFor(x => x.Question).NotEmpty();
            RuleFor(x => x.Answer1).NotEmpty();
            RuleFor(x => x.Answer2).NotEmpty();
            RuleFor(x => x.Answer3).NotEmpty();
            RuleFor(x => x.Answer4).NotEmpty();
            RuleFor(x => x.CorrectAnswer).NotEmpty().NotEqual(0);
            RuleFor(x => x.Points).NotEmpty().NotEqual(0);
            RuleFor(x => x.CourseId).NotEmpty().NotEqual(0);
        }
    }
}
