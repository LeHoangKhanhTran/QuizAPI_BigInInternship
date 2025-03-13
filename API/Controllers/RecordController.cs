using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.DTOs;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/records")]
public class RecordController: ControllerBase
{
    public RecordController()
    {
        
    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<IEnumerable<RecordDto>> GetRecordById(Guid id)
    // {
    //     return Ok();
    // }

    // [HttpGet("{userId}")]
    // public async Task<ActionResult<IEnumerable<RecordDto>> GetRecordsByUserId(Guid userId)
    // {

    // }

    // [HttpPost]
    // public async Task<ActionResult<RecordDto>> CreateRecord(CreateRecordDto recordDto)
    // {

    // }
}