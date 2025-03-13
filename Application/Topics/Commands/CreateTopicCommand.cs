using MediatR;
using QuizAPI.DTOs;

public record CreateTopicCommand(CreateTopicDto topicDto): IRequest<Guid>;