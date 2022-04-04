namespace Infrastructure.InfluxDb;

public static class ServiceRegistration
{
    public static void AddInfluxDBInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<InfluxDbContextOptions>(configuration.GetSection("InfluxDbContextOptions"));
        services.AddScoped<InfluxDbContext>();



    }
}
