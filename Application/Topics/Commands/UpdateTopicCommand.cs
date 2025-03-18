using MediatR;
using QuizAPI.DTOs;

public record UpdateTopicCommand(Guid Id, UpdateTopicDto TopicDto): IRequest<Unit>;