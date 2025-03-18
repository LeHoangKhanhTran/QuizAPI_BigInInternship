
using QuizAPI.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly QuizDbContext _context;
    public ITopicRepository Topics { get; }
    public IQuestionRepository Questions { get; }
    public IRecordRepository Records { get; }

    public UnitOfWork(QuizDbContext context)
    {
        _context = context;
        Topics = new TopicRepository(_context);
        Questions = new QuestionRepository(_context);
        Records = new RecordRepository(_context);
    }
    public async Task BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
    public async Task CommitTransactionAsync() => await _context.Database.CommitTransactionAsync();
    public async Task RollbackTransactionAsync() => await _context.Database.RollbackTransactionAsync();
    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}