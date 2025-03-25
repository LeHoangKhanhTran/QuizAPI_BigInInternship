namespace QuizAPI.DTOs;
public record QuestionDto(Guid ID, string Content, List<TopicDto> Topics, Guid CorrectChoiceID, List<ChoiceDto> Choices);
public record QuestionInfoDto(Guid ID, string Content, Guid CorrectChoiceID, List<ChoiceDto> Choices);
public record CreateQuestionDto(string Content, CreateChoiceDto CorrectChoice, List<CreateChoiceDto> OtherChoices);
public record UpdateQuestionDto(string? Content, CreateChoiceDto? CorrectChoice, List<CreateChoiceDto>? OtherChoices);