using MediatR;

public record RemoveQuestionFromTopicCommand(Guid TopicId, Guid QuestionId): IRequest<Unit>;