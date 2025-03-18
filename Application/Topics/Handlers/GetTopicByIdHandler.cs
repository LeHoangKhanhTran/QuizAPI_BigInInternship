using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Interfaces;

public class GetTopicByIdHandler : IRequestHandler<GetTopicByIdQuery, TopicDto>
{
    private readonly ITopicRepository _topicRepository;
    private readonly IMapper _mapper;
    public GetTopicByIdHandler(ITopicRepository topicRepository, IMapper mapper)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
    }
    public async Task<TopicDto> Handle(GetTopicByIdQuery request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetTopicById(request.Id);
        return _mapper.Map<TopicDto>(topic);
    }
}
