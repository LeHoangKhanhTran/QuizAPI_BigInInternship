using AutoMapper;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class TopicMappingProfile: Profile
{
    public TopicMappingProfile()
    {
        CreateMap<Topic, TopicDto>().ReverseMap();
        CreateMap<Topic, TopicInfoDto>().ReverseMap();
        CreateMap<Topic, CreateTopicDto>().ReverseMap();
        CreateMap<Topic, UpdateTopicDto>().ReverseMap();
    }
}