using QuizAPI.Entities;

namespace QuizAPI.DTOs;
public record ChoiceDto
{
    public Guid Id { get; init; }
    public string Content { get; init; }
    public ChoiceDto(Guid id, string content)
    {
        Id = id;
        Content = content;
    }
}

public record CreateChoiceDto(string Content);
