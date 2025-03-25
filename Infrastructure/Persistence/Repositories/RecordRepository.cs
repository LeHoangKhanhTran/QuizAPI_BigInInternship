using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

public class RecordRepository : IRecordRepository
{
    private readonly QuizDbContext _quizDbContext;
    public RecordRepository(QuizDbContext quizDbContext)
    {
        _quizDbContext = quizDbContext;
    }
    public async Task CreateRecord(Record record)
    {
        await _quizDbContext.Records.AddAsync(record);
        await _quizDbContext.SaveChangesAsync();
    }

    public async Task<Record> GetRecordById(Guid id)
    {
        return await _quizDbContext.Records.Where(r => r.ID == id).Include(r => r.Topic).Include(r => r.Answers).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Record>> GetRecords(Guid? userId)
    {
        if (userId is null || userId == Guid.Empty) return await _quizDbContext.Records.Include(r => r.Topic).Include(r => r.Answers).ToListAsync();
        return await _quizDbContext.Records.Where(r => r.UserID == userId).Include(r => r.Topic).Include(r => r.Answers).ToListAsync();
    }
}