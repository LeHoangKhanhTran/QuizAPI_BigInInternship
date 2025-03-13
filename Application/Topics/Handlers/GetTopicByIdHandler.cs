using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Interfaces;

public class GetTopicByIdHandler : IRequestHandler<GetTopicByIdQuery, TopicInfoDto>
{
    private readonly ITopicRepository _topicRepository;
    private readonly IMapper _mapper;
    public GetTopicByIdHandler(ITopicRepository topicRepository, IMapper mapper)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
    }
    public async Task<TopicInfoDto> Handle(GetTopicByIdQuery request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetTopicById(request.Id);
        return _mapper.Map<TopicInfoDto>(topic);
    }
}
