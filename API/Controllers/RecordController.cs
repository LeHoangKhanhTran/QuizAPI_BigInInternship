using System.Drawing;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using QuizAPI.DTOs;
namespace QuizAPI.Controllers;

[ApiController]
[Route("api/records")]
public class RecordController: ControllerBase
{
    private readonly ISender _sender;
    private readonly IMemoryCache _cache;
    public RecordController(ISender sender, IMemoryCache cache)
    {
        _sender = sender;
        _cache = cache;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecordDto>> GetRecordById(Guid id)
    {
        var record = await _sender.Send(new GetRecordByIdQuery(id));
        return Ok(record);
    }
    
    [Authorize(Policy = "AdminAndUserResourcePolicy")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecordDto>>> GetRecords([FromQuery] Guid userId)
    {
        var records = await _cache.GetOrCreateAsync("records", async entry => 
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            entry.SlidingExpiration = TimeSpan.FromMinutes(2);
            return await _sender.Send(new GetRecordsQuery(userId));
        });
        return Ok(records);
    }

    [HttpPost]
    public async Task<ActionResult<RecordDto>> CreateRecord(CreateRecordDto recordDto)
    {
        var record = await _sender.Send(new CreateRecordCommand(recordDto));
        return CreatedAtAction(nameof(GetRecordById), new { id = record.ID }, record);
    }
}