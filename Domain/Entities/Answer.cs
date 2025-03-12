using QuizAPI.Entities;

public class Answer
{
    public Guid ID { get; set; }
    public Guid QuestionId { get; set; }
    public Guid ChoiceId { get; set; }
    public required Record Record { get; set; }
}