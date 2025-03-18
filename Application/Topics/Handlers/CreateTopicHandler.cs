using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class CreateTopicHandler : IRequestHandler<CreateTopicCommand, TopicDto>
{
    private readonly ITopicRepository _topicRepository;
    private readonly IMapper _mapper;
    public CreateTopicHandler(ITopicRepository topicRepository, IMapper mapper)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
    }
    public async Task<TopicDto> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var topicDto = request.TopicDto;
        var topic = new Topic 
        {
            ID = Guid.NewGuid(),
            Title = topicDto.Title,
            Description = topicDto.Description
        };  
        await _topicRepository.CreateTopic(topic);
        return _mapper.Map<TopicDto>(topic);
    }
}