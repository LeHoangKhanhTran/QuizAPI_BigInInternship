using MediatR;
using QuizAPI.DTOs;
using QuizAPI.Entities;

public class GetAllTopicsQuery: IRequest<IEnumerable<TopicInfoDto>> {  }
