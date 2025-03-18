using MediatR;
using QuizAPI.DTOs;

public record UpdateQuestionCommand(Guid Id, UpdateQuestionDto QuestionDto): IRequest<Unit>;