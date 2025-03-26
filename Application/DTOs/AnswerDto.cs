using QuizAPI.DTOs;
using QuizAPI.Entities;

public record AnswerDto(Guid ID, Guid QuestionId, Guid ChoiceId);
public record CreateAnswerDto(Guid QuestionId, Guid ChoiceId);
