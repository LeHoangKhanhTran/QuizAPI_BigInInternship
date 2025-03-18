namespace QuizAPI.Entities;

public class Question 
{
    public Guid ID { get; set; }
    public required string Content { get; set; }
    public required List<Topic> Topics { get; set; }
    public required Guid CorrectChoiceID { get; set; }
    public virtual required List<Choice> Choices { get; set; }
}

