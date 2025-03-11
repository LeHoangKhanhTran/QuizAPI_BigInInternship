using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Entities;

public class Topic 
{
    public Guid ID { get; set; }
    [Required]
    public required string Title { get; set; }
    public required string Description { get; set; }
    public IEnumerable<Question>? Questions { get; set; }
    public IEnumerable<Record>? Records { get; set; }
}