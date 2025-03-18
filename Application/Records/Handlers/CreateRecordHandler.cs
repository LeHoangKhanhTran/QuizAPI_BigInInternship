using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class CreateRecordHandler : IRequestHandler<CreateRecordCommand, RecordDto>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRecordHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = (UnitOfWork)unitOfWork;
        _mapper = mapper;
    }
    public async Task<RecordDto> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
    {
        var recordDto = request.RecordDto;
        var existingTopic = await _unitOfWork.Topics.GetTopicById(recordDto.TopicID);
        if (existingTopic is null) throw new NotFoundException(nameof(Topic), recordDto.TopicID);
        int score = 0;
        foreach (CreateAnswerDto answer in recordDto.Answers)
        {
            if (answer.ChoiceId == answer.Question.CorrectChoiceID)
            {
                score++;
            }
        }
        Record record = new()
        {
            ID = Guid.NewGuid(),
            Topic = existingTopic,
            Answers = recordDto.Answers.Select(a => new Answer() 
            {
                ID = Guid.NewGuid(),
                QuestionId = a.Question.ID,
                ChoiceId = a.ChoiceId,
            }).ToList(), 
            Score = score,
            UserID = recordDto.UserID
        };
        await _unitOfWork.Records.CreateRecord(record);
        return _mapper.Map<RecordDto>(record);
    }
}