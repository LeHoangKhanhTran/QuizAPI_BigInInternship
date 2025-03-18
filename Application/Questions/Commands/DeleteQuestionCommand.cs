using MediatR;

public record DeleteQuestionCommand(Guid Id): IRequest<Unit>;