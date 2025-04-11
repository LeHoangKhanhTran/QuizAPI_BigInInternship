using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Interfaces;

public class GetRecordsHandler : IRequestHandler<GetRecordsQuery, IEnumerable<RecordDto>>
{
    private readonly IRecordRepository _recordRepository;
    public GetRecordsHandler(IRecordRepository recordRepository, IMapper mapper)
    {
        _recordRepository = recordRepository;
    }

    public async Task<IEnumerable<RecordDto>> Handle(GetRecordsQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var records = await _recordRepository.GetRecords(userId);
        return records.Select(r => new RecordDto(r.ID, new TopicInfoDto(r.Topic.ID, r.Topic.Title, r.Topic.Description), r.Answers.Select(a => new AnswerDto(a.ID, a.QuestionId, a.ChoiceId)).ToList(), r.UserID, r.Score, r.CreatedDate));
    }
}