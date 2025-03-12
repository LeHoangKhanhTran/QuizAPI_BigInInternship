namespace QuizAPI.DTOs;
public record QuestionDto(Guid ID, string Content, IEnumerable<TopicDto> Topics, Guid CorrectChoiceID, IEnumerable<ChoiceDto> Choices);
public record CreateQuestionDto(string Content, IEnumerable<TopicDto> Topics, Guid CorrectChoiceID, IEnumerable<ChoiceDto> Choices);
public record UpdateQuestionDto(string Content, IEnumerable<TopicDto> Topics, Guid CorrectChoiceID, IEnumerable<ChoiceDto> Choices);