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
        return await _quizDbContext.Records.Where(r => r.ID == id).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Record>> GetRecordsByUserId(Guid userId)
    {
        return await _quizDbContext.Records.Where(r => r.UserID == userId).ToListAsync();
    }
}