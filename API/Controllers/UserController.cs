using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.DTOs;
using QuizAPI.Entities;

[ApiController]
[Route("api/users")]
public class UserController: ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ISender _sender;
    public UserController(UserManager<User> userManager, ISender sender)
    {
        _userManager = userManager;
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null) return NotFound();
        var records = await _sender.Send(new GetRecordsQuery(id));
        var recordDtos = records.Select(r => new RecordInfoDto(r.ID, r.Topic, r.UserID, r.Score, r.CreatedDate)).ToList();
        UserDto userDto = new(user.Email, recordDtos);
        return Ok(userDto);
    }
}