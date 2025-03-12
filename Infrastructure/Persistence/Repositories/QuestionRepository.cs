using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class QuestionRepository : IQuestionRepository
{
    public Task CreateQuestion(Question question)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTopic(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Question> GetQuestionById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Question>> GetQuestionsByTopic()
    {
        throw new NotImplementedException();
    }

    public Task UpdateQuestion(Question question)
    {
        throw new NotImplementedException();
    }
}