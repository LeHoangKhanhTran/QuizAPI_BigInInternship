using AutoMapper;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class QuestionMappingProfile: Profile
{
    public QuestionMappingProfile()
    {
        CreateMap<Question, QuestionDto>().ReverseMap().ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices ?? new()));
        CreateMap<Question, CreateQuestionDto>().ReverseMap();
        CreateMap<Question, UpdateQuestionDto>().ReverseMap();
    }
}
