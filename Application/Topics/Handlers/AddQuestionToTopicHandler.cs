using MediatR;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class AddQuestionToTopicHandler : IRequestHandler<AddQuestionToTopicCommand, Unit>
{
    private readonly UnitOfWork _unitOfWork;
    public AddQuestionToTopicHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = (UnitOfWork)unitOfWork;
    }
    public async Task<Unit> Handle(AddQuestionToTopicCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingTopic = await _unitOfWork.Topics.GetTopicById(request.TopicId);
            var existingQuestion = await _unitOfWork.Questions.GetQuestionById(request.QuestionId);
            if (existingTopic is null) throw new NotFoundException(nameof(Topic), request.TopicId);
            if (existingQuestion is null) throw new NotFoundException(nameof(Question), request.QuestionId);
            if (existingTopic.Questions is null || !existingTopic.Questions.Any()) existingTopic.Questions = new List<Question>();
            if (existingQuestion.Topics is null || !existingQuestion.Topics.Any()) existingQuestion.Topics = new List<Topic>();
            await _unitOfWork.BeginTransactionAsync();
            existingTopic.Questions.Add(existingQuestion);
            existingQuestion.Topics.Add(existingTopic);
            await _unitOfWork.CommitTransactionAsync();
            await _unitOfWork.SaveChangesAsync();
        }
        catch(NotFoundException) {}
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
        }
        
        return Unit.Value;
    }
}