using System.Drawing;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.DTOs;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/records")]
public class RecordController: ControllerBase
{
    private readonly ISender _sender;
    public RecordController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<RecordDto>>> GetRecordById(Guid id)
    {
        var record = await _sender.Send(new GetRecordByIdQuery(id));
        return Ok(record);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecordDto>>> GetRecordsByUserId([FromQuery] Guid userId)
    {
        var records = await _sender.Send(new GetRecordsQuery(userId));
        return Ok(records);
    }

    [HttpPost]
    public async Task<ActionResult<RecordDto>> CreateRecord(CreateRecordDto recordDto)
    {
        var record = await _sender.Send(new CreateRecordCommand(recordDto));
        return CreatedAtAction(nameof(GetRecordById), new { id = record.ID }, record);
    }
}