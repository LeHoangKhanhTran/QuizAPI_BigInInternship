using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Entities;

public class Topic 
{
    public Guid ID { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public List<Question> Questions { get; set; } = new();
    public List<Record> Records { get; set; } = new();
}