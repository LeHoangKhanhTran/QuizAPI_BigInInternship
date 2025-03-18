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
        var question = await _quizDbContext.Questions.Where(q => q.ID == id).SingleOrDefaultAsync();
        return question;
    }

    public async Task<IEnumerable<Question>> GetQuestions(Guid? topicId)
    {
        if (topicId is null) return await _quizDbContext.Questions.Where(q => q.Topics.Any(t => t.ID == topicId)).ToListAsync();
        return await _quizDbContext.Questions.ToListAsync();
    }

    public async Task UpdateQuestion(Question question)
    {
        _quizDbContext.Questions.Update(question);
        await _quizDbContext.SaveChangesAsync();
    }
}