using SparkplugNet.VersionB;

namespace WebApi.Sparkplug;

public class SparkplugDataAdapter
{
    private readonly IMediator _mediator;

    private VersionB.SparkplugApplication _sparkplugApplication;
    private SparkplugApplicationOptions _sparkplugApplicationOptions;

    public SparkplugDataAdapter(IOptions<SparkplugDataAdapterOptions> options, IMediator mediator)
    {
        SparkplugDataAdapterOptions parameter = options.Value;

        _mediator = mediator;

        var applicationMetrics = new List<Metric>();
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

        _sparkplugApplication.SparkplugNodeConnectionChangedEvent = HandleNodeConnectionChanged;
        _sparkplugApplication.SparkplugDeviceConnectionChangedEvent = HandleDeviceConnectionChanged;
        _sparkplugApplication.SparkplugMetricsChangedEvent = HandleMetricsUpdated;
    }

    public async Task StartApplicationAsync()
    {
        await _sparkplugApplication.Start(_sparkplugApplicationOptions);
    }

    public async void HandleNodeConnectionChanged(SparkplugNodeConnectionChangedEvent e)
    {
        var notification = new EonNodeConnectionChangedEvent(e.EonNodeId, e.Connected);

        await _mediator.Publish(notification);
    }
    
    public async void HandleDeviceConnectionChanged(SparkplugDeviceConnectionChangedEvent e)
    {
        var notification = new DeviceConnectionChangedEvent(e.EonNodeId, e.DeviceId, e.Connected);

        await _mediator.Publish(notification);
    }

    public async void HandleMetricsUpdated(SparkplugMetricsChangedEvent e)
    {
        var notification = new TagValuesUpdatedEvent(e.EonNodeId, e.DeviceId, e.TagName, e.Value);

        await _mediator.Publish(notification);
    }
}
