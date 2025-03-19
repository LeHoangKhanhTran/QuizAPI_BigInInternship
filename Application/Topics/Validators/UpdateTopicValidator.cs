using FluentValidation;

public class UpdateTopicValidator : AbstractValidator<UpdateTopicCommand>
{
    public UpdateTopicValidator()
    {
        RuleFor(x => x.TopicDto.Title).MaximumLength(100).WithMessage("Title should be no longer than 100 characters.");
        RuleFor(x => x.TopicDto.Description).MaximumLength(250).WithMessage("Description should be no longer than 250 characters.");
    }
}

