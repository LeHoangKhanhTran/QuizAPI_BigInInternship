using AutoMapper;
using MediatR;
using QuizAPI.Entities;

public class RemoveQuestionFromTopicHandler : IRequestHandler<RemoveQuestionFromTopicCommand, Unit>
{   
    public UnitOfWork _unitOfWork;
    public IMapper _mapper;
    public RemoveQuestionFromTopicHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = (UnitOfWork)unitOfWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(RemoveQuestionFromTopicCommand request, CancellationToken cancellationToken)
    {
        try 
        {
            var existingTopic = await _unitOfWork.Topics.GetTopicById(request.TopicId);
            var existingQuestion = await _unitOfWork.Questions.GetQuestionById(request.QuestionId);
            if (existingTopic is null) throw new NotFoundException(nameof(Topic), request.TopicId);
            if (existingQuestion is null) throw new NotFoundException(nameof(Question), request.QuestionId);
            await _unitOfWork.BeginTransactionAsync();
            existingQuestion.Topics.Remove(existingTopic);
            existingTopic.Questions.Remove(existingQuestion);
            await _unitOfWork.CommitTransactionAsync();
            await _unitOfWork.SaveChangesAsync();
        }
        catch(NotFoundException) {}
        catch(Exception) {
            await _unitOfWork.RollbackTransactionAsync();
        }
        return Unit.Value;
    }
}