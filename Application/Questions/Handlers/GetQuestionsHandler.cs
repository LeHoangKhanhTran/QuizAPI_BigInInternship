using System.Runtime.InteropServices;
using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, IEnumerable<QuestionDto>>
{
    public IQuestionRepository _questionRepository;
    public IMapper _mapper;
    public GetQuestionsHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<QuestionDto>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetQuestions(request.TopicId);
        foreach (Question question in questions)
        {
            var choices = question.Choices.ToList();
            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(choices));
            question.Choices = choices;
        }
        return questions.Select(_mapper.Map<QuestionDto>);
    }
}