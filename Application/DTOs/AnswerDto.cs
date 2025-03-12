using QuizAPI.DTOs;
using QuizAPI.Entities;

public record AnswerDto(Guid ID, Guid QuestionId, Guid ChoiceId, RecordDto RecordDto);
public record CreateAnswerDto(Guid QuestionId, Guid ChoiceId);
