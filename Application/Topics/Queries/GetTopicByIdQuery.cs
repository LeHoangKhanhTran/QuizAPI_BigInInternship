using MediatR;
using QuizAPI.DTOs;

public record GetTopicByIdQuery(Guid Id): IRequest<TopicDto> 
{ 
    // public Guid Id { get; }
    // public GetTopicByIdQuery(Guid id)
    // {
    //     Id = id;
    // }
}