using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class CreateRecordHandler : IRequestHandler<CreateRecordCommand, RecordDto>
{
    private readonly UnitOfWork _unitOfWork;
    public CreateRecordHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = (UnitOfWork)unitOfWork;
    }
    public async Task<RecordDto> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
    {
        var recordDto = request.RecordDto;
        var existingTopic = await _unitOfWork.Topics.GetTopicById(recordDto.TopicId);
        if (existingTopic is null) throw new NotFoundException(nameof(Topic), recordDto.TopicId);
        int score = 0;
        foreach (CreateAnswerDto answer in recordDto.Answers)
        {
            var question = await _unitOfWork.Questions.GetQuestionById(answer.QuestionId);
            if (answer.ChoiceId == question.CorrectChoiceID)
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
                QuestionId = a.QuestionId,
                ChoiceId = a.ChoiceId,
            }).ToList(), 
            Score = score,
            UserID = recordDto.UserId   
        };
        await _unitOfWork.Records.CreateRecord(record);
        TopicInfoDto topicInfoDto = new(existingTopic.ID, existingTopic.Title, existingTopic.Description);
        return new RecordDto(record.ID, topicInfoDto, record.Answers.Select(a => new AnswerDto(a.ID, a.QuestionId, a.ChoiceId)).ToList(),record.UserID, score, record.CreatedDate);
    }
}