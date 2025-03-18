using MediatR;
using QuizAPI.DTOs;

public record CreateQuestionCommand(CreateQuestionDto QuestionDto): IRequest<QuestionDto>;