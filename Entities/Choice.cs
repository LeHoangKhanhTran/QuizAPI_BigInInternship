namespace QuizAPI.Entities;

public class Choice 
{
    public Guid ID { get; set; }
    public required string Content { get; set; }
    public required Question Quesition { get; set; }
}