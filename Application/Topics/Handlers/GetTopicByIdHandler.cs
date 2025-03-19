using System.Runtime.InteropServices;
using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class GetTopicByIdHandler : IRequestHandler<GetTopicByIdQuery, TopicDto>
{
    private readonly ITopicRepository _topicRepository;
    public GetTopicByIdHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }
    public async Task<TopicDto> Handle(GetTopicByIdQuery request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetTopicById(request.Id);
        var questions = topic.Questions.Select(q => new QuestionInfoDto(q.ID, q.Content, q.CorrectChoiceID, q.Choices.Select(c => new ChoiceDto(c.ID, c.Content)).ToList())).ToList();
        for (int i = 0; i < questions.Count; i++)
        {
            var choices = questions[i].Choices.ToList();
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(choices));
            questions[i] = questions[i] with {Choices = choices};
        }
        var topicDto = new TopicDto(topic.ID, topic.Title, topic.Description, questions);
        return topicDto;
    }
}
