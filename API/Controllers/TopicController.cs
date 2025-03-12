using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.DTOs;
using QuizAPI.Entities;
using QuizAPI.Interfaces;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/topics")]
public class TopicController: ControllerBase
{
    private readonly ITopicRepository _topicRepository;
    private readonly IMapper _mapper;
    public TopicController(ITopicRepository topicRepository, IMapper mapper)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TopicDto>> GetAllTopics()
    {
        var topics = await _topicRepository.GetAllTopics();
        return topics.Select(_mapper.Map<TopicDto>);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TopicDto>> GetTopicById(Guid id)
    {
        var topic = await _topicRepository.GetTopicById(id);
        return _mapper.Map<TopicDto>(topic);
    }

    [HttpPost]
    public async Task<ActionResult<TopicDto>> CreateTopic(CreateTopicDto topicDto) 
    {
        var topic = new Topic()
        {
            ID = Guid.NewGuid(),
            Title = topicDto.Title,
            Description = topicDto.Description
        };
        await _topicRepository.CreateTopic(topic);
        return CreatedAtAction(nameof(GetTopicById), new {id = topic.ID}, _mapper.Map<TopicDto>(topic));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTopic(Guid id, UpdateTopicDto topicDto)
    {
        var topic = _mapper.Map<Topic>(topicDto);
        topic.ID = id;
        await _topicRepository.UpdateTopic(topic);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTopic(Guid id)
    {
        await _topicRepository.DeleteTopic(id);
        return NoContent();
    }
}