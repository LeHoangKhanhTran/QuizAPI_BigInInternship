namespace QuizAPI.Entities;

public class Question 
{
    public Guid ID { get; set; }
    public required string Content { get; set; }
    public required IEnumerable<Topic> Topics { get; set; }
    public required Choice CorrectChoice { get; set; }
    public required IEnumerable<Choice> Choices { get; set; }
}

