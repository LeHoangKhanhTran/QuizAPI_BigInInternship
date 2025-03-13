namespace QuizAPI.DTOs;
public record RecordDto(Guid ID, TopicInfoDto Topic, IEnumerable<AnswerDto> AnswerDtos, Guid UserID, int Score, DateTimeOffset CreatedDate);
public record RecordInfoDto(Guid ID, TopicInfoDto Topic, Guid UserID, int Score, DateTimeOffset CreatedDate);
public record CreateRecordDto(Guid TopicID, IEnumerable<AnswerDto> AnswerDtos, Guid UserID);
