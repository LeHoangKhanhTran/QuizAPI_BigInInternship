using AutoMapper;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class QuestionMappingProfile: Profile
{
    public QuestionMappingProfile()
    {
        CreateMap<Question, QuestionDto>().ReverseMap();
        CreateMap<Question, CreateQuestionDto>().ReverseMap();
        CreateMap<Question, UpdateQuestionDto>().ReverseMap();
    }
}
