using SparkplugNet.VersionB;

namespace WebApi.Sparkplug;

public class SparkplugDataAdapter
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    private VersionB.SparkplugApplication _sparkplugApplication;
    private SparkplugApplicationOptions _sparkplugApplicationOptions;

    public SparkplugDataAdapter(IOptions<SparkplugDataAdapterOptions> options, IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;

        SparkplugDataAdapterOptions parameter = options.Value;

        /*var metrics = new List<Metric>()
        {
            new Metric { Name = "tag000", ValueCase = DataType.Double, DoubleValue = 123.123 },
            new Metric { Name = "tag111", ValueCase = DataType.Int32, IntValue = 111 }
        };

        var applicationMetrics = new List<Metric>(metrics);*/

        var applicationMetrics = new List<Metric>()
        {
            new Metric { Name = "tag000", ValueCase = DataType.Int32, IntValue = 111 }
        };

        _sparkplugApplication = new SparkplugApplication(applicationMetrics, Log.Logger);
        _sparkplugApplicationOptions = new SparkplugApplicationOptions(
            parameter.BrokerAddress,
            parameter.Port,
            parameter.ClientId,
            parameter.UserName,
            parameter.Password,
            parameter.UseTls,
            parameter.ScadaHostIdentifier,
            TimeSpan.FromSeconds(parameter.ReconnectInterval),
            parameter.IsPrimaryApplication,
            null,
            null,
            new CancellationToken()
            );
    }

    public async Task StartApplicationAsync()
    {
        await _sparkplugApplication.Start(_sparkplugApplicationOptions);

        _sparkplugApplication.SparkplugNodeConnectionChangedEvent = HandleNodeConnectionChanged;
        _sparkplugApplication.SparkplugDeviceConnectionChangedEvent = HandleDeviceConnectionChanged;
        _sparkplugApplication.SparkplugMetricsChangedEvent = HandleMetricsUpdated;
    }

    public async Task StopApplicationAsync()
    {
        await _sparkplugApplication.Stop();
    }

    public void AddKnownMetric(string name, EDataType dataType)
    {
        var metric = new Metric();
        switch (dataType)
        {
            case EDataType.Boolean:
                metric = new Metric { Name = name, ValueCase = DataType.Boolean, BooleanValue = false };
                break;
            case EDataType.Integer:
                metric = new Metric { Name = name, ValueCase = DataType.Int32, IntValue = 0 };
                break;
            case EDataType.Double:
                metric = new Metric { Name = name, ValueCase = DataType.Double, DoubleValue = 0.0 };
                break;

        }

        _sparkplugApplication.KnownMetrics.Add(metric);
    }

    public async void HandleNodeConnectionChanged(SparkplugNodeConnectionChangedEvent e)
    {
        var notification = new EonNodeConnectionChangedEvent(e.EonNodeId, e.Connected);

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetService<IMediator>();

            await mediator.Publish(notification);
        } 
    }
    
    public async void HandleDeviceConnectionChanged(SparkplugDeviceConnectionChangedEvent e)
    {
        var notification = new DeviceConnectionChangedEvent(e.EonNodeId, e.DeviceId, e.Connected);

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetService<IMediator>();

            await mediator.Publish(notification);
        }
    }

    public async void HandleMetricsUpdated(SparkplugMetricsChangedEvent e)
    {
        var notification = new TagValuesUpdatedEvent(e.EonNodeId, e.DeviceId, e.TagName, e.Value);

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetService<IMediator>();

            await mediator.Publish(notification);
        }
    }

    public List<Metric> KnownMetrics()
    {
        return _sparkplugApplication.KnownMetrics;
    }
}
