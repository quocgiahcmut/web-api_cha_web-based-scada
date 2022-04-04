namespace Domain.Repositories;

public interface ITagRepository : IRepository
{
    Task Add(Tag tag);
    Task Update(Tag tag);
    Task Delete(Tag tag);
    Task<Tag> FindByTagName(string tagName);
}
