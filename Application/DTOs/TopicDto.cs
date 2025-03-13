using QuizAPI.Entities;

namespace QuizAPI.DTOs;

public record TopicDto(Guid ID, string Title, string Description, IEnumerable<QuestionDto>? Questions=null, IEnumerable<RecordDto>? Records=null);
public record TopicInfoDto(Guid ID, string Title, string Description);
public record CreateTopicDto(string Title, string Description);
public record UpdateTopicDto(string Title, string Description);