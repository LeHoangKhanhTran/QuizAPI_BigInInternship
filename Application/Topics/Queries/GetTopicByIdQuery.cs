using MediatR;
using QuizAPI.DTOs;

public class GetTopicByIdQuery: IRequest<TopicInfoDto> 
{ 
    public Guid Id { get; }
    public GetTopicByIdQuery(Guid id)
    {
        Id = id;
    }
}