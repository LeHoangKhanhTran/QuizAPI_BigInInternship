using AutoMapper;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class RecordMappingProfile: Profile
{
    public RecordMappingProfile()
    {
        CreateMap<Record, RecordDto>().ReverseMap();
        CreateMap<Record, CreateRecordDto>().ReverseMap();
    }
}