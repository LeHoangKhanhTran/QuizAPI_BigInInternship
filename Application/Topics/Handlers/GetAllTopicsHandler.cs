using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder.Extensions;
using QuizAPI.DTOs;
using QuizAPI.Interfaces;

public class GetAllTopicsHandler : IRequestHandler<GetAllTopicsQuery, IEnumerable<TopicInfoDto>>
{
    private readonly ITopicRepository _topicRepository;
    private readonly IMapper _mapper;
    public GetAllTopicsHandler(ITopicRepository topicRepository, IMapper mapper)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TopicInfoDto>> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
    {
        return (await _topicRepository.GetAllTopics()).Select(_mapper.Map<TopicInfoDto>);
    }
}