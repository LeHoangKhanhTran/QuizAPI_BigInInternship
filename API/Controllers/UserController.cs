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

    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
        if (userId is null) return NotFound();
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null) return NotFound();
        var records = await _sender.Send(new GetRecordsQuery(Guid.Parse(userId)));
        var recordDtos = records.Select(r => new RecordInfoDto(r.ID, r.Topic, r.UserId, r.Score, r.CreatedDate)).ToList();
        UserInfoDto userDto = new(Guid.Parse(userId), user.Email, (await _userManager.GetRolesAsync(user)).ToList());
        return Ok(userDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null) return NotFound();
        var records = await _sender.Send(new GetRecordsQuery(id));
        var recordDtos = records.Select(r => new RecordInfoDto(r.ID, r.Topic, r.UserId, r.Score, r.CreatedDate)).ToList();
        UserDto userDto = new(user.Email, recordDtos);
        return Ok(userDto);
    }
}