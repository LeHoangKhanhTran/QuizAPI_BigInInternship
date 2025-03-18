using MediatR;
using QuizAPI.Interfaces;

public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionCommand, Unit>
{
    private readonly UnitOfWork _unitOfWork;
    public DeleteQuestionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = (UnitOfWork)unitOfWork;
    }
    public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Questions.DeleteQuestion(request.Id);
        return Unit.Value;
    }
}