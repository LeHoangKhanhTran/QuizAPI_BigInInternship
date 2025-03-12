using QuizAPI.Entities;

namespace QuizAPI.DTOs;
public record TopicDto(Guid ID, string Title, string Description, IEnumerable<QuestionDto>? Questions, IEnumerable<RecordDto> Records);
public record CreateTopicDto(string Title, string Description);
public record UpdateTopicDto(string Title, string Description);