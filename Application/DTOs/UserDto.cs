namespace QuizAPI.DTOs;
public record UserInfoDto(Guid Id, string Email, List<string> Roles);
public record UserDto(string Email, List<RecordInfoDto>? Records);
public record RegisterDto(string Email, string Password);
public record LoginDto(string Email, string Password);