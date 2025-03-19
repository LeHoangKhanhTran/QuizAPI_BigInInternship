namespace QuizAPI.DTOs;
public record RecordDto(Guid ID, TopicInfoDto Topic, List<AnswerDto> Answers, Guid UserID, int Score, DateTimeOffset CreatedDate);
public record RecordInfoDto(Guid ID, TopicInfoDto Topic, Guid UserID, int Score, DateTimeOffset CreatedDate);
public record CreateRecordDto(Guid TopicID, List<CreateAnswerDto> Answers, Guid UserID);
