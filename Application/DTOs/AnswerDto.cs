using QuizAPI.DTOs;
using QuizAPI.Entities;

public record AnswerDto(Guid ID, Question Question, Guid ChoiceId, RecordDto RecordDto);
public record CreateAnswerDto(QuestionDto Question, Guid ChoiceId);
