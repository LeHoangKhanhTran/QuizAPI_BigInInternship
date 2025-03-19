using AutoMapper;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class TopicMappingProfile: Profile
{
    public TopicMappingProfile()
    {
        CreateMap<Topic, TopicDto>().ReverseMap().ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions ?? new()));
        CreateMap<Topic, TopicInfoDto>().ReverseMap();
        CreateMap<Topic, CreateTopicDto>().ReverseMap();
        CreateMap<Topic, UpdateTopicDto>().ReverseMap();
    }
}