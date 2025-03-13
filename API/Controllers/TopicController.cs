using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.DTOs;
using QuizAPI.Entities;
using QuizAPI.Interfaces;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/topics")]
public class TopicController: ControllerBase
{
    private readonly ISender _sender;
    public TopicController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TopicInfoDto>>> GetAllTopics()
    {
        var topicsInfo = await _sender.Send(new GetAllTopicsQuery());
        return Ok(topicsInfo); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TopicDto>> GetTopicById(Guid id)
    {
        var topicInfo = await _sender.Send(new GetTopicByIdQuery(id));
        return Ok(topicInfo);
    }

    [HttpPost]
    public async Task<ActionResult<TopicDto>> CreateTopic(CreateTopicDto topicDto) 
    {
        var topic = _sender.Send(new CreateTopicCommand(topicDto));
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTopic(Guid id, UpdateTopicDto topicDto)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTopic(Guid id)
    {
        return NoContent();
    }

    [HttpPost("{topicId}/questions/{questionId}")]
    public async Task<ActionResult> AddQuestionToTopic(Guid topicId, Guid questionId)
    {
        return NoContent();
    }
}