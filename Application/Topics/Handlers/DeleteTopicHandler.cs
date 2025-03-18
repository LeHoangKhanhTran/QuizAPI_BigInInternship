using MediatR;
using QuizAPI.Interfaces;

public class DeleteTopicHandler : IRequestHandler<DeleteTopicCommand, Unit>
{
    private readonly ITopicRepository _topicRepository;
    public DeleteTopicHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }
    public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        await _topicRepository.DeleteTopic(request.Id);
        return Unit.Value;
    }
}