using MediatR;
using QuizAPI.DTOs;

public record GetQuestionByIdQuery(Guid Id): IRequest<QuestionDto>;
