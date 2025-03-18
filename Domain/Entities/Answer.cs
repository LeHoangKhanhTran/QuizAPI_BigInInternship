using QuizAPI.Entities;

public class Answer
{
    public Guid ID { get; set; }
    public Guid QuestionId { get; set; }
    public Guid ChoiceId { get; set; }
    public Record Record { get; set; } = null!;
}