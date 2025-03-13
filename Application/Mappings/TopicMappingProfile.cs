using AutoMapper;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class TopicMappingProfile: Profile
{
    public TopicMappingProfile()
    {
        CreateMap<Topic, TopicDto>().ReverseMap();
        // .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions))
        // .ForMember(dest => dest.Records, opt => opt.MapFrom(src => src.Records));
        CreateMap<Topic, TopicInfoDto>().ReverseMap();
        CreateMap<Topic, CreateTopicDto>().ReverseMap();
        CreateMap<Topic, UpdateTopicDto>().ReverseMap();
    }
}