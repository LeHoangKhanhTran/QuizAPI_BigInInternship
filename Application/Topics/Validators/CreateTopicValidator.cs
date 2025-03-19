using FluentValidation;

public class CreateTopicValidator : AbstractValidator<CreateTopicCommand>
{
    public CreateTopicValidator()
    {
        RuleFor(x => x.TopicDto.Title).NotEmpty().WithMessage("Title for topic must be provided").MaximumLength(100).WithMessage("Title should be no longer than 100 characters.");
        RuleFor(x => x.TopicDto.Description).NotEmpty().WithMessage("Description for topic must be provided").MaximumLength(250).WithMessage("Description should be no longer than 250 characters.");
    }
}

