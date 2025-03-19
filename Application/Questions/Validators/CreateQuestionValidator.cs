using FluentValidation;
using QuizAPI.DTOs;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.QuestionDto.Content).NotEmpty().WithMessage("Content must be provided").MaximumLength(300).WithMessage("Content should not be longer than 300 characters.");
        RuleFor(x => x.QuestionDto.CorrectChoice).NotEmpty().WithMessage("Correct choice must be provided.");
        RuleFor(x => x.QuestionDto.OtherChoices).NotEmpty().WithMessage("Other choices must be provided").Must(c => c.Count <= 4).WithMessage("Question must have at most 4 other choices").Must(c => c.Count > 1).WithMessage("Question must have at least 1 other choice.");
        RuleForEach(x => x.QuestionDto.OtherChoices).SetValidator(new ChoiceValidator());
    }
}

public class ChoiceValidator : AbstractValidator<CreateChoiceDto>
{
    public ChoiceValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Choice content must be provided.");
    }
}

