using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using QuizAPI.DTOs;
using QuizAPI.Entities;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionController: ControllerBase 
{
    private readonly ISender _sender;
    private readonly IMemoryCache _cache;
    public QuestionController(ISender sender, IMemoryCache cache)
    {
        _sender = sender;
        _cache = cache;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions([FromQuery] Guid topicId)
    {
        // var questions = await _cache.GetOrCreateAsync("questions", async entry =>
        // {
        //     entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
        //     entry.SlidingExpiration = TimeSpan.FromMinutes(2);
        //     return await _sender.Send(new GetQuestionsQuery(topicId));
        // });
        var questions = await _sender.Send(new GetQuestionsQuery(topicId));
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionDto>> GetQuestionById(Guid id)
    {
        var question = await _sender.Send(new GetQuestionByIdQuery(id));
        return Ok(question);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<QuestionDto>> CreateQuestion(CreateQuestionDto questionDto)
    {
        var question = await _sender.Send(new CreateQuestionCommand(questionDto));
        _cache.Remove("questions");
        return CreatedAtAction(nameof(GetQuestionById), new { id = question.ID }, question);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuestion(Guid id, UpdateQuestionDto questionDto)
    {
        await _sender.Send(new UpdateQuestionCommand(id, questionDto));
        _cache.Remove("questions");
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")] 
    public async Task<IActionResult> DeleteQuestion(Guid id)
    {
        await _sender.Send(new DeleteQuestionCommand(id));
        _cache.Remove("questions");
        return NoContent();
    }
}