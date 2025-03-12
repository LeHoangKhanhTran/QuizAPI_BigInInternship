using Microsoft.AspNetCore.Mvc;
using QuizAPI.Entities;

namespace QuizAPI.Interfaces;

public interface ITopicRepository 
{
    public Task<IEnumerable<Topic>> GetAllTopics();
    public Task<Topic> GetTopicById(Guid id);
    public Task CreateTopic(Topic topic);
    public Task UpdateTopic(Topic topic);
    public Task DeleteTopic(Guid id);
}