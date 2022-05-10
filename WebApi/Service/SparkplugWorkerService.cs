namespace WebApi.Service;

public class SparkplugWorkerService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<SparkplugWorkerService> _logger;
    private readonly SparkplugDataAdapter _sparkplugDataAdapter;

    public SparkplugWorkerService(IServiceScopeFactory serviceScopeFactory, ILogger<SparkplugWorkerService> logger, SparkplugDataAdapter sparkplugDataAdapter)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
        _sparkplugDataAdapter = sparkplugDataAdapter;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _sparkplugDataAdapter.StartApplicationAsync();
        _logger.LogInformation("Sparkplug Connected Broker: {1}", _sparkplugDataAdapter.IsConnected);

        _sparkplugDataAdapter.NodeConnectionChanged = HandleNodeConnectionChanged;
        _sparkplugDataAdapter.DeviceConnectionChanged = HandleDeviceConnectionChanged;
        _sparkplugDataAdapter.MetricsUpdated = HandleMetricsUpdated;
    }

    public async void HandleNodeConnectionChanged(SparkplugNodeConnectionChangedEvent e)
    {
        Console.WriteLine("node");
        var notification = new EonNodeConnectionChangedEvent(e.EonNodeId, e.Connected);

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetService<IMediator>();

            await mediator.Publish(notification);
        }
    }

    public async void HandleDeviceConnectionChanged(SparkplugDeviceConnectionChangedEvent e)
    {
        Console.WriteLine("device");
        var notification = new DeviceConnectionChangedEvent(e.EonNodeId, e.DeviceId, e.Connected);

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetService<IMediator>();

            await mediator.Publish(notification);
        }
    }

    public async void HandleMetricsUpdated(SparkplugMetricsChangedEvent e)
    {
        Console.WriteLine("metrics");
        var notification = new TagValuesUpdatedEvent(e.EonNodeId, e.DeviceId, e.TagName, e.Value);

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetService<IMediator>();

            await mediator.Publish(notification);
        }
    }
}
