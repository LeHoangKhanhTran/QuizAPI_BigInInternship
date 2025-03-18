using MediatR;
using QuizAPI.DTOs;

public record CreateRecordCommand(CreateRecordDto RecordDto): IRequest<RecordDto>;