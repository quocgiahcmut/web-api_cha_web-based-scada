namespace Domain.Repositories;

public interface ITagValueRepository
{
    Task UpdateTag(string id, bool value);
    Task UpdateTag(string id, int value);
    Task UpdateTag(string id, double value);
    Task<object> GetLatestValue(string id);
}
