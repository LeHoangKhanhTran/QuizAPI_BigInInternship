using MediatR;

public record DeleteTopicCommand(Guid Id): IRequest<Unit>;