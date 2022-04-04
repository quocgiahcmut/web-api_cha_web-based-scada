namespace Infrastructure.Persistence.Repositories;

public class TagRepository : BaseRepository, ITagRepository
{
    public TagRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Task Add(Tag tag)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Tag tag)
    {
        throw new NotImplementedException();
    }

    public Task<Tag> FindByTagName(string tagName)
    {
        throw new NotImplementedException();
    }

    public Task Update(Tag tag)
    {
        throw new NotImplementedException();
    }
}
