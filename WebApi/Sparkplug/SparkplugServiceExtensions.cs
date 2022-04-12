namespace WebApi.Sparkplug;

public static class SparkplugServiceExtensions
{
    public static void AddSparkplugApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SparkplugDataAdapterOptions>(configuration.GetSection("SparkplugDataAdapterOptions"));
        services.AddSingleton<SparkplugDataAdapter>();
    }
}
