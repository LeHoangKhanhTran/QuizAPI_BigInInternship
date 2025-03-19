using MediatR;
using QuizAPI.DTOs;

public record GetRecordsQuery(Guid? UserId): IRequest<IEnumerable<RecordInfoDto>>;
