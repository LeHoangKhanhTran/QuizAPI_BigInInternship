using AutoMapper;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class ChoiceMappingProfile: Profile
{
    public ChoiceMappingProfile()
    {
        CreateMap<Choice, ChoiceDto>().ReverseMap();
        CreateMap<Choice, CreateChoiceDto>().ReverseMap();
    }
}