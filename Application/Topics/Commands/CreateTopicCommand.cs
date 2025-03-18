using MediatR;
using QuizAPI.DTOs;

public record CreateTopicCommand(CreateTopicDto TopicDto): IRequest<TopicDto>;