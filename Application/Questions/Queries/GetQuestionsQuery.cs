using MediatR;
using QuizAPI.DTOs;

public record GetQuestionsQuery(Guid? TopicId): IRequest<IEnumerable<QuestionDto>>;