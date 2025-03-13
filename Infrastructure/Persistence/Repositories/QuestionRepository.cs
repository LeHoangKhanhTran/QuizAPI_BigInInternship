using Microsoft.EntityFrameworkCore;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuizDbContext _quizDbContext;
    public QuestionRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }
    public async Task CreateQuestion(Question question)
    {
        await _quizDbContext.Questions.AddAsync(question);
        await _quizDbContext.SaveChangesAsync();
    }

    public async Task DeleteQuestion(Guid id)
    {
        await _quizDbContext.Questions.Where(q => q.ID == id).ExecuteDeleteAsync();
        await _quizDbContext.SaveChangesAsync();
    }

    public async Task<Question> GetQuestionById(Guid id)
    {
        return await _quizDbContext.Questions.Where(q => q.ID == id).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Question>> GetQuestionsByTopicId(Guid topicId)
    {
        return await _quizDbContext.Questions.Where(q => q.Topics.Any(t => t.ID == topicId)).ToListAsync();
    }

    public async Task UpdateQuestion(Question question)
    {
        _quizDbContext.Questions.Update(question);
        await _quizDbContext.SaveChangesAsync();
    }
}