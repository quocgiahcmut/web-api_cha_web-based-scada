namespace Infrastructure.InfluxDb.Core;

public class InfluxDbContext
{
    public string Token { get; private set; }
    public string Organization { get; private set; }
    public string Bucket { get; private set; }
    public string InfluxDbUrl { get; set; }

    public InfluxDbContext(string token, string organization, string bucket, string influxDbUrl)
    {
        Token = token;
        Organization = organization;
        Bucket = bucket;
        InfluxDbUrl = influxDbUrl;
    }

    public InfluxDbContext(IOptions<InfluxDbContextOptions> options)
    {
        InfluxDbContextOptions parameter = options.Value;

        Token = parameter.Token;
        Organization = parameter.Organization;
        Bucket = parameter.Bucket;
        InfluxDbUrl = parameter.InfluxDbUrl;
    }

    public string GetFluxQuery(DateTime startTime, DateTime stopTime, string measurement, string field)
    {
        string startHeader = "from(bucket:\"";
        string endHeader = "\")";
        string startRange = "|> range(start:";
        string midRange = "Z, stop: ";
        string endRange = "Z)";
        string startFilter = "|> filter(fn: (r) => r._measurement == \"";
        string midFilter = "\" and r._field == \"";
        string endFilter = "\")";

        string start = startTime.ToString("yyyy-MM-ddThh:mm:ss");
        string stop = stopTime.ToString("yyyy-MM-ddThh:mm:ss");

        string header = startHeader + Bucket + endHeader;
        string range = startRange + start + midRange + stop + endRange;
        string filter = startFilter + measurement + midFilter + field + endFilter;
        string fluxQuery = header + range + filter;

        return fluxQuery;
    }

    public string GetFlux24HourQuery(string measurement, string field)
    {
        string startHeader = "from(bucket:\"";
        string endHeader = "\")";
        string startFilter = "|> filter(fn: (r) => r._measurement == \"";
        string midFilter = "\" and r._field == \"";
        string endFilter = "\")";

        string header = startHeader + Bucket + endHeader;
        string range = "|> range(start: -24h)";
        string filter = startFilter + measurement + midFilter + field + endFilter;
        string fluxQuery = header + range + filter;

        return fluxQuery;
    }

    public async Task<bool> WriteAsync(PointData pointData)
    {
        using var client = InfluxDBClientFactory.Create(InfluxDbUrl, Token);
        var writeApiAsync = client.GetWriteApiAsync();

        try
        {
            await writeApiAsync.WritePointAsync(pointData, Bucket, Organization);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<TimeSeriesModel>> QueryAsync(string fluxQuery)
    {
        var timeSeriesModels = new List<TimeSeriesModel>();

        using var client = InfluxDBClientFactory.Create(InfluxDbUrl, Token);
        var queryApiAsync = client.GetQueryApi();

        var tables = await queryApiAsync.QueryAsync(fluxQuery, Organization);

        foreach (var table in tables)
        {
            foreach (var record in table.Records)
            {
                var timeSeriesModel = new TimeSeriesModel(record.GetField(), record.GetValue());

                timeSeriesModels.Add(timeSeriesModel);
            }
        }

        return timeSeriesModels;
    }
}
