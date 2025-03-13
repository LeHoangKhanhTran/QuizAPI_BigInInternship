using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class CreateTopicHandler : IRequestHandler<CreateTopicCommand, Guid>
{
    private readonly ITopicRepository _topicRepository;
    private readonly IMapper _mapper;
    public CreateTopicHandler(ITopicRepository topicRepository, IMapper mapper)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var topicDto = request.topicDto;
        var topic = new Topic 
        {
            ID = Guid.NewGuid(),
            Title = topicDto.Title,
            Description = topicDto.Description
        };  
        await _topicRepository.CreateTopic(topic);
        return topic.ID;
    }
}