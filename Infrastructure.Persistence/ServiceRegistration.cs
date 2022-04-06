namespace Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), builder =>
            builder.MigrationsAssembly("WebApi")
        ));

        #region Add Repositories

        services.AddTransient<IEonNodeRepository,EonNodeRepository>();
        services.AddTransient<IDeviceRepository,DeviceRepository>();
        services.AddTransient<ITagRepository,TagRepository>();

        #endregion
    }
}
