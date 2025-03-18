using MediatR;
using QuizAPI.DTOs;

public record GetRecordsByUserIdQuery(Guid UserId): IRequest<IEnumerable<RecordInfoDto>>;
