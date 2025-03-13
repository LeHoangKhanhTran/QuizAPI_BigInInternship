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
        await _quizDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Topic>> GetAllTopics()
    {
        return await _quizDbContext.Topics.ToListAsync();
    }

    public async Task<Topic> GetTopicById(Guid id)
    {
        return await _quizDbContext.Topics.Where(t => t.ID == id).SingleOrDefaultAsync();
    }

    public async Task UpdateTopic(Topic topic)
    {
        _quizDbContext.Topics.Update(topic);
        await _quizDbContext.SaveChangesAsync();
    }
}