using QuizAPI.DTOs;
using QuizAPI.Entities;

namespace QuizAPI.Interfaces;

public interface IRecordRepository 
{
    public Task<IEnumerable<Record>> GetRecordsByUserId(Guid userId);
    public Task<Record> GetRecordById(Guid id);
    public Task CreateRecord(Record record);
}