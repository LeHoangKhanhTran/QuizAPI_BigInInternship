using MediatR;
using QuizAPI.DTOs;

public record GetRecordByIdQuery(Guid Id): IRequest<RecordDto>;