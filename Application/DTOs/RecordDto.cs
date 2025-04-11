namespace QuizAPI.DTOs;
public record RecordDto(Guid ID, TopicInfoDto Topic, List<AnswerDto> Answers, Guid UserId, int Score, DateTimeOffset CreatedDate);
public record RecordInfoDto(Guid ID, TopicInfoDto Topic, Guid UserId, int Score, DateTimeOffset CreatedDate);
public record CreateRecordDto(Guid TopicId, List<CreateAnswerDto> Answers, Guid UserId);
