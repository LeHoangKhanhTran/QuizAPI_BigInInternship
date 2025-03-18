using QuizAPI.Interfaces;

public interface IUnitOfWork 
{
    public Task BeginTransactionAsync();
    public Task CommitTransactionAsync();
    public Task RollbackTransactionAsync();
    public Task<int> SaveChangesAsync();
}