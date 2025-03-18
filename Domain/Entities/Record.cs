namespace QuizAPI.Entities;

public class Record 
{
    public Guid ID { get; set; }
    public required Topic Topic{ get; set; }
    public virtual required List<Answer> Answers { get; set; }
    public Guid UserID { get; set; }
    public int Score { get; set; }
    public DateTimeOffset CreatedDate { get; init; } = DateTimeOffset.Now;
}
