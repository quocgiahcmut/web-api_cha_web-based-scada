namespace Infrastructure.Persistence.Repositories;

public class EonNodeRepository : BaseRepository, IEonNodeRepository
{
    public EonNodeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Task Add(EonNode node)
    {
        throw new NotImplementedException();
    }

    public Task Delete(EonNode node)
    {
        throw new NotImplementedException();
    }

    public Task<EonNode> FindById(string eonNodeId)
    {
        throw new NotImplementedException();
    }

    public Task Update(EonNode node)
    {
        throw new NotImplementedException();
    }
}
