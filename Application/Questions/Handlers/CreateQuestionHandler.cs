using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, QuestionDto>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    public CreateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }
    public async Task<QuestionDto> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var questionDto = request.QuestionDto;
        var correctChoice = new Choice() 
        {
            ID = Guid.NewGuid(),
            Content = questionDto.CorrectChoice.Content
        };
        Question question = new()
        {
            ID = Guid.NewGuid(),
            Content = questionDto.Content,
            Topics = new List<Topic>(),
            CorrectChoiceID = correctChoice.ID,
            Choices = questionDto.OtherChoices.Select(choice => new Choice() 
            {
                ID = Guid.NewGuid(),
                Content = choice.Content,
            }).Append(correctChoice).ToList()
        };
        await _questionRepository.CreateQuestion(question);
        return _mapper.Map<QuestionDto>(question);
    }
}