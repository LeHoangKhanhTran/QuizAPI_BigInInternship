using MediatR;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class UpdateTopicHandler : IRequestHandler<UpdateTopicCommand, Unit>
{
    private readonly ITopicRepository _topicRepository;
    public UpdateTopicHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }
    public async Task<Unit> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var existingTopic = await _topicRepository.GetTopicById(request.Id);
        if (existingTopic is null) throw new NotFoundException(nameof(Topic), request.Id);
        var topicDto = request.TopicDto;
        existingTopic.Title = topicDto.Title ?? existingTopic.Title;
        existingTopic.Description = topicDto.Description ?? existingTopic.Description;
        existingTopic.Questions = existingTopic.Questions;
        existingTopic.Records = existingTopic.Records;
        await _topicRepository.UpdateTopic(existingTopic);
        return Unit.Value;
    }
}