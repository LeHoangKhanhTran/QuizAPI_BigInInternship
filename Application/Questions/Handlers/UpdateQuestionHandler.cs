using AutoMapper;
using MediatR;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, Unit>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    public UpdateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var existingQuestion = await _questionRepository.GetQuestionById(request.Id);
        if (existingQuestion is null) throw new NotFoundException(nameof(Question), request.Id);
        var questionDto = request.QuestionDto;
        var correctChoice = questionDto.CorrectChoice is null ? null : new Choice()
        {
            ID = Guid.NewGuid(),
            Content = questionDto.CorrectChoice.Content
        };
        var choices = questionDto.OtherChoices?.Select(_mapper.Map<Choice>).ToList() ?? existingQuestion.Choices;
        if (correctChoice is not null) choices.Add(correctChoice);
        existingQuestion.Content = questionDto.Content ?? existingQuestion.Content;
        existingQuestion.CorrectChoiceID = correctChoice?.ID ?? existingQuestion.CorrectChoiceID;
        existingQuestion.Choices = choices;
        await _questionRepository.UpdateQuestion(existingQuestion);
        return Unit.Value;
    }
}