using MediatR;

public record AddQuestionToTopicCommand(Guid TopicId, Guid QuestionId): IRequest<Unit>;