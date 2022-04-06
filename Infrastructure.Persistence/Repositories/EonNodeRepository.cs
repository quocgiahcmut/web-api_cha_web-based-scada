namespace Infrastructure.Persistence.Repositories;

public class EonNodeRepository : BaseRepository, IEonNodeRepository
{
    public EonNodeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task Add(EonNode node)
    {
        await _context.EonNodes.AddRangeAsync(node);
    }

    public void Delete(EonNode node)
    {
        _context.EonNodes.Remove(node);
    }

    public async Task<EonNode?> FindById(string eonNodeId)
    {
        return await _context.EonNodes
            .Include(e => e.Devices)
            .ThenInclude(d => d.Tags)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == eonNodeId);
    }

    public void Update(EonNode node)
    {
        _context.EonNodes.Update(node);
    }
}
