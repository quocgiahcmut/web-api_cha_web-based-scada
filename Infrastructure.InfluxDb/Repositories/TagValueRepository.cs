namespace Infrastructure.InfluxDb.Repositories;

public class TagValueRepository : InfluxBaseRepository, ITagValueRepository
{
    public TagValueRepository(InfluxDbContext context) : base(context)
    {
    }

    public async Task<object> GetLatestValue(string table, string id)
    {
        var query = _context.GetFlux24HourQuery(table, id);

        var result = await _context.QueryAsync(query);

        return result.Last().FieldValue;
    }

    public async Task UpdateTag(string id, bool value)
    {
        PointData point = PointData
            .Measurement("tableBool")
            .Field(id, value)
            .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

        await _context.WriteAsync(point);
    }

    public async Task UpdateTag(string id, int value)
    {
        PointData point = PointData
            .Measurement("tableInt")
            .Field(id, value)
            .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

        await _context.WriteAsync(point);
    }

    public async Task UpdateTag(string id, double value)
    {
        PointData point = PointData
            .Measurement("tableDouble")
            .Field(id, value)
            .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

        await _context.WriteAsync(point);
    }
}
