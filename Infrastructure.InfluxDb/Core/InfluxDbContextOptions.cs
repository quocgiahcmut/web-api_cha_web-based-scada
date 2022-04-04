namespace Infrastructure.InfluxDb.Core;

public class InfluxDbContextOptions
{
    public string Token { get; set; }
    public string Organization { get; set; }
    public string Bucket { get; set; }
    public string InfluxDbUrl { get; set; }
}
