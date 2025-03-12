using AutoMapper;

public class AnswerMappingProfile: Profile
{
    public AnswerMappingProfile()
    {
        CreateMap<Answer, AnswerDto>().ReverseMap();
        CreateMap<Answer, CreateAnswerDto>().ReverseMap();
    }
}