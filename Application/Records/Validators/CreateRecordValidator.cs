using FluentValidation;

public class CreateRecordValidator : AbstractValidator<CreateRecordCommand>
{
    public CreateRecordValidator()
    {
        RuleFor(x => x.RecordDto.TopicID).NotEmpty().WithMessage("Topic's id must be provided.");
        RuleFor(x => x.RecordDto.UserID).NotEmpty().WithMessage("User's id must be provided.");
        RuleFor(x => x.RecordDto.Answers).NotEmpty().WithMessage("Answers must be provided.");
        RuleForEach(x => x.RecordDto.Answers).SetValidator(new AnswerValidator());
    }
}

public class AnswerValidator: AbstractValidator<CreateAnswerDto>
{
    public AnswerValidator()
    {
        RuleFor(x => x.QuestionId).NotEmpty().WithMessage("Question's id must be provided.");
        RuleFor(x => x.ChoiceId).NotEmpty().WithMessage("Choice's id must be provided.");
    }
}

