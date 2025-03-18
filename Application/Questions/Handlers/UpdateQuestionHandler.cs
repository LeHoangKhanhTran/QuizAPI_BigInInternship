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
        try 
        {
            var existingQuestion = await _questionRepository.GetQuestionById(request.Id);
            if (existingQuestion is null) throw new NotFoundException(nameof(Question), request.Id);
            var questionDto = request.QuestionDto;
            Question question = new()
            {
                Topics = existingQuestion.Topics,
                Content = questionDto.Content ?? existingQuestion.Content,
                CorrectChoiceID = questionDto.CorrectChoiceID ?? existingQuestion.CorrectChoiceID,
                Choices = questionDto.Choices.Select(_mapper.Map<Choice>).ToList() ?? existingQuestion.Choices
            };
            await _questionRepository.UpdateQuestion(question);
        }
        catch(Exception)
        {

        }
        return Unit.Value;
    }
}