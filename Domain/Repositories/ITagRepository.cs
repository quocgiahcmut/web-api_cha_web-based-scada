namespace Domain.Repositories;

public interface ITagRepository : IRepository
{
    Task Add(Tag tag);
    void Update(Tag tag);
    void Delete(Tag tag);
    Task<Tag> FindByTagName(string tagName);
    Task<IEnumerable<Tag>> GetAllTag();
}
