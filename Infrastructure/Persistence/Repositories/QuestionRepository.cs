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
        var question = await _quizDbContext.Questions.Where(q => q.ID == id).Include(q => q.Topics).SingleOrDefaultAsync();
        return question;
    }

    public async Task<IEnumerable<Question>> GetQuestions(Guid? topicId)
    {
        if (topicId is not null && topicId != Guid.Empty) return await _quizDbContext.Questions.Where(q => q.Topics.Any(t => t.ID == topicId)).Include(q => q.Topics).ToListAsync();
        return await _quizDbContext.Questions.Include(q => q.Topics).ToListAsync();
    }

    public async Task UpdateQuestion(Question question)
    {
        if (question.Choices is not null) 
        {
            var oldChoices = await _quizDbContext.Choices.Where(c => c.Question.ID == question.ID).ToListAsync();
            if (oldChoices.Count > 0) 
            {
                _quizDbContext.RemoveRange(oldChoices); 
                await _quizDbContext.SaveChangesAsync();
            }
            _quizDbContext.Choices.AddRange(question.Choices); 
            
        }
         _quizDbContext.Questions.Update(question);
        await _quizDbContext.SaveChangesAsync();
    }
}