using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.DTOs;
using QuizAPI.Entities;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/questions")]
public class QuesitionController: ControllerBase 
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    public QuesitionController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions([FromQuery] Guid topicId)
    {
        var questions = await _sender.Send(new GetQuestionsQuery(topicId));
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionDto>> GetQuestionById(Guid id)
    {
        var question = await _sender.Send(new GetQuestionByIdQuery(id));
        return Ok(question);
    }

    [HttpPost]
    public async Task<ActionResult<QuestionDto>> CreateQuestion(CreateQuestionDto questionDto)
    {
        var question = await _sender.Send(new CreateQuestionCommand(questionDto));
        return CreatedAtAction(nameof(GetQuestionById), new { id = question.ID }, question);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuestion(Guid id, UpdateQuestionDto questionDto)
    {
        await _sender.Send(new UpdateQuestionCommand(id, questionDto));
        return NoContent();
    }

    [HttpDelete("{id}")] 
    public async Task<IActionResult> DeleteQuestion(Guid id)
    {
        await _sender.Send(new DeleteQuestionCommand(id));
        return NoContent();
    }
}