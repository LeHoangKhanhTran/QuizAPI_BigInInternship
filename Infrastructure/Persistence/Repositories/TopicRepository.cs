using Microsoft.EntityFrameworkCore;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class TopicRepository : ITopicRepository
{
    private readonly QuizDbContext _quizDbContext;
    public TopicRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }
    public async Task CreateTopic(Topic topic)
    {
        await _quizDbContext.Topics.AddAsync(topic);
        await _quizDbContext.SaveChangesAsync();
    }

    public async Task DeleteTopic(Guid id)
    {
        await _quizDbContext.Topics.Where(t => t.ID == id).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Topic>> GetAllTopics()
    {
        return await _quizDbContext.Topics.ToListAsync();
    }

    public async Task<Topic> GetTopicById(Guid id)
    {
        return await _quizDbContext.Topics.Where(t => t.ID == id).FirstOrDefaultAsync();
    }

    public async Task UpdateTopic(Topic topic)
    {
        var existingTopic = await _quizDbContext.Topics.FindAsync(topic.ID);
        if (existingTopic is not null)
        {
            existingTopic.Title = topic.Title;
            existingTopic.Description = topic.Description;
            existingTopic.Questions = topic.Questions;
            existingTopic.Records = topic.Records;
            _quizDbContext.Topics.Update(existingTopic);
            await _quizDbContext.SaveChangesAsync();
        }
    }
}