namespace Infrastructure.InfluxDb;

public static class ServiceRegistration
{
    public static void AddInfluxDbInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<InfluxDbContextOptions>(configuration.GetSection("InfluxDbContextOptions"));
        services.AddScoped<InfluxDbContext>();

        #region Add Repositories

        services.AddTransient<ITagValueRepository, TagValueRepository>();

        #endregion
    }
}
