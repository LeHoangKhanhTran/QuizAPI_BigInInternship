using FluentValidation;

public class UpdateQuestionValidator : AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionValidator()
    {
        RuleFor(x => x.QuestionDto.Content).MaximumLength(300).WithMessage("Content should not be longer than 300 characters.");
        RuleFor(x => x.QuestionDto.OtherChoices).Must(c => c?.Count <= 4).WithMessage("Question must have at most 4 other choices").Must(c => c?.Count > 1).WithMessage("Question must have at least 1 other choice.").When(c => c.QuestionDto.OtherChoices != null);
        RuleForEach(x => x.QuestionDto.OtherChoices).SetValidator(new ChoiceValidator()).When(x => x.QuestionDto.OtherChoices != null);
    }
}