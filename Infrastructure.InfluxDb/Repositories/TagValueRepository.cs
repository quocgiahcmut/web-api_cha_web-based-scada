namespace Infrastructure.InfluxDb.Repositories;

public class TagValueRepository : InfluxBaseRepository, ITagValueRepository
{
    public TagValueRepository(InfluxDbContext context) : base(context)
    {
    }

    public Task<object> GetLatestValue(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTag(string id, bool value)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTag(string id, int value)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTag(string id, double value)
    {
        throw new NotImplementedException();
    }
}
