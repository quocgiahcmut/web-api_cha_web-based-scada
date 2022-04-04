namespace Infrastructure.InfluxDb.Core;

public class InfluxDbContext
{
    public string Token { get; private set; }
    public string Organization { get; private set; }
    public string Bucket { get; private set; }
    public string InfluxDbUrl { get; set; }
    public InfluxDBClient Client { get; set; }


    private readonly WriteApiAsync _writeApiAsync;
    public WriteApiAsync WriteApiAsync
    {
        get { return _writeApiAsync; }
    }

    private readonly QueryApiSync _queryApiSync;

    public QueryApiSync QueryApiSync
    {
        get { return _queryApiSync; }
    }

    public InfluxDbContext(string token, string organization, string bucket, string influxDbUrl)
    {
        Token = token;
        Organization = organization;
        Bucket = bucket;
        InfluxDbUrl = influxDbUrl;

        Client = InfluxDBClientFactory.Create(InfluxDbUrl, Token.ToCharArray());
        _writeApiAsync = Client.GetWriteApiAsync();
        _queryApiSync = Client.GetQueryApiSync();
    }

    public InfluxDbContext(IOptions<InfluxDbContextOptions> options)
    {
        InfluxDbContextOptions parameter = options.Value;

        Token = parameter.Token;
        Organization = parameter.Organization;
        Bucket = parameter.Bucket;
        InfluxDbUrl = parameter.InfluxDbUrl;

        Client = InfluxDBClientFactory.Create(InfluxDBUrl, Token.ToCharArray());
        _writeApiAsync = Client.GetWriteApiAsync();
        _queryApiSync = Client.GetQueryApiSync();
    }
}
