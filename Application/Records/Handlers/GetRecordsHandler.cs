using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Interfaces;

public class GetRecordsHandler: IRequestHandler<GetRecordsQuery, IEnumerable<RecordInfoDto>>
{
    private readonly IRecordRepository _recordRepository;
    public GetRecordsHandler(IRecordRepository recordRepository, IMapper mapper)
    {
        _recordRepository = recordRepository;
    }

    public async Task<IEnumerable<RecordInfoDto>> Handle(GetRecordsQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var records = await _recordRepository.GetRecords(userId);
        return records.Select(r => new RecordInfoDto(r.ID, new TopicInfoDto(r.Topic.ID, r.Topic.Title, r.Topic.Description), r.UserID, r.Score, r.CreatedDate));
    }
}