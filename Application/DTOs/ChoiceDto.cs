using QuizAPI.Entities;

namespace QuizAPI.DTOs;
public record ChoiceDto(Guid Id, string Content, QuestionDto QuestionDto);
public record CreateChoiceDto(string Content, QuestionDto QuestionDto);
