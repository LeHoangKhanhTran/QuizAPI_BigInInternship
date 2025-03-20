namespace QuizAPI.DTOs;
public record UserDto(string Email, List<RecordInfoDto>? Records);
public record RegisterDto(string Email, string Password);
public record LoginDto(string Email, string Password);