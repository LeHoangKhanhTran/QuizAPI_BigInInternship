using System.Globalization;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using QuizAPI.DTOs;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/topics")]
public class TopicController: ControllerBase
{
    private readonly ISender _sender;
    private readonly IMemoryCache _cache;
    public TopicController(ISender sender, IMemoryCache cache)
    {
        _sender = sender;
        _cache = cache;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TopicInfoDto>>> GetAllTopics()
    {
        var topicsInfo = await _cache.GetOrCreateAsync("topics", async entry => 
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            entry.SlidingExpiration = TimeSpan.FromMinutes(2);
            return await _sender.Send(new GetAllTopicsQuery());
        });
        return Ok(topicsInfo); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TopicDto>> GetTopicById(Guid id)
    {
        var topic = await _sender.Send(new GetTopicByIdQuery(id));
        return Ok(topic);
    }

    [Authorize(Policy = "AdminOnlyPolicy")]
    [HttpPost]
    public async Task<ActionResult<TopicDto>> CreateTopic(CreateTopicDto topicDto) 
    {
        var topic = await _sender.Send(new CreateTopicCommand(topicDto));
        return CreatedAtAction(nameof(GetTopicById), new {id = topic.ID}, topic);
    }

    [Authorize(Policy = "AdminOnlyPolicy")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTopic(Guid id, UpdateTopicDto topicDto)
    {
        await _sender.Send(new UpdateTopicCommand(id, topicDto));
        return NoContent();
    }

    [Authorize(Policy = "AdminOnlyPolicy")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTopic(Guid id)
    {
        await _sender.Send(new DeleteTopicCommand(id));
        return NoContent();
    }

    [Authorize(Policy = "AdminOnlyPolicy")]
    [HttpPost("{topicId}/questions/{questionId}")]
    public async Task<ActionResult> AddQuestionToTopic(Guid topicId, Guid questionId)
    {
        await _sender.Send(new AddQuestionToTopicCommand(topicId, questionId));
        return NoContent();
    }
}