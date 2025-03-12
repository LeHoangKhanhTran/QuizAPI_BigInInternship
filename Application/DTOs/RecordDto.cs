namespace QuizAPI.DTOs;
public record RecordDto(Guid ID, TopicDto Topic, IEnumerable<AnswerDto> AnswerDtos);
public record CreateRecordDto();
