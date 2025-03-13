using Microsoft.AspNetCore.Mvc;
using QuizAPI.DTOs;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/questions")]
public class QuesitionController: ControllerBase 
{
    public QuesitionController()
    {
        
    }

    // [HttpGet("{topicId}")]
    // public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestionsByTopicId(Guid topicId)
    // {

    // }

    // [HttpPost]
    // public async Task<ActionResult<QuestionDto>> CreateQuestion(CreateQuestionDto questionDto)
    // {

    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateQuestion(Guid id, UpdateQuestionDto questionDto)
    // {

    // }

    // [HttpDelete("{id}")] 
    // public async Task<IActionResult> DeleteQuestion(Guid id)
    // {
        
    // }
}