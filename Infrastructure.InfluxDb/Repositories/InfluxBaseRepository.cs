namespace Infrastructure.InfluxDb.Repositories;

public class InfluxBaseRepository
{
    protected readonly InfluxDbContext _context;
    protected readonly string org;
    protected readonly string bucket;

    public InfluxBaseRepository(InfluxDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        org = _context.Organization;
        bucket = _context.Bucket;
    }
}
