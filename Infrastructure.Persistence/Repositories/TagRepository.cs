namespace Infrastructure.Persistence.Repositories;

public class TagRepository : BaseRepository, ITagRepository
{
    public TagRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task Add(Tag tag)
    {
        await _context.Tags.AddRangeAsync(tag);
    }

    public void Delete(Tag tag)
    {
        _context.Tags.Remove(tag);
    }

    public Task<Tag?> FindByTagName(string tagName)
    {
        return _context.Tags
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Name == tagName);
    }

    public void Update(Tag tag)
    {
        _context.Tags.Update(tag);
    }
}