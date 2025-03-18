namespace QuizAPI.Entities;

public class Choice 
{
    public Guid ID { get; set; }
    public required string Content { get; set; }
    public  Question Question { get; set; } = null;
}