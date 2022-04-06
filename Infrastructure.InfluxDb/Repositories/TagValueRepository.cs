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

    public async Task UpdateTag(string id, bool value)
    {
        PointData point = PointData
            .Measurement("tableBool")
            .Field(id, value)
            .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

        await _context.WriteApiAsync.WritePointAsync(point);
    }

    public async Task UpdateTag(string id, int value)
    {
        PointData point = PointData
            .Measurement("tableInt")
            .Field(id, value)
            .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

        await _context.WriteApiAsync.WritePointAsync(point);
    }

    public async Task UpdateTag(string id, double value)
    {
        PointData point = PointData
            .Measurement("tableDouble")
            .Field(id, value)
            .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

        await _context.WriteApiAsync.WritePointAsync(point);
    }
}
