using AutoMapper;
using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Interfaces;

public class GetQuestionByIdHandler : IRequestHandler<GetQuestionByIdQuery, QuestionDto>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    public GetQuestionByIdHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }
    public async Task<QuestionDto> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetQuestionById(request.Id);
        return _mapper.Map<QuestionDto>(question);
    }
}
