using QuizAPI.Entities;

namespace QuizAPI.DTOs;

public record TopicDto(Guid ID, string Title, string Description, List<QuestionInfoDto> Questions)
{
    public TopicDto(Guid ID, string Title, string Description) : this(ID, Title, Description, new List<QuestionInfoDto>()) { }
}

public record TopicInfoDto(Guid ID, string Title, string Description);
public record CreateTopicDto(string Title, string Description);
public record UpdateTopicDto(string? Title, string? Description);