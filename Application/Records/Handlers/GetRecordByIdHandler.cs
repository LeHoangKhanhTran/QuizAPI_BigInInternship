using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Interfaces;

public class GetRecordByIdHandler : IRequestHandler<GetRecordByIdQuery, RecordDto>
{
    private readonly IRecordRepository _recordRepository;
    private readonly IMapper _mapper;
    public GetRecordByIdHandler(IRecordRepository recordRepository, IMapper mapper)
    {
        _recordRepository = recordRepository;
        _mapper = mapper;
    }
    public async Task<RecordDto> Handle(GetRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var record = await _recordRepository.GetRecordById(request.Id);
        var topicDto = new TopicInfoDto(record.Topic.ID, record.Topic.Title, record.Topic.Description);
        var recordDto = new RecordDto(record.ID, topicDto, record.Answers.Select(a => new AnswerDto(a.ID, a.QuestionId, a.ChoiceId)).ToList(), record.UserID, record.Score, record.CreatedDate);
        return recordDto;
    }
}