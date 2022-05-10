using SparkplugNet.VersionB;

namespace WebApi.Sparkplug;

public class SparkplugDataAdapter
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    private VersionB.SparkplugApplication _sparkplugApplication;
    private SparkplugApplicationOptions _sparkplugApplicationOptions;

    public Action<SparkplugNodeConnectionChangedEvent> NodeConnectionChanged;
    public Action<SparkplugDeviceConnectionChangedEvent> DeviceConnectionChanged;
    public Action<SparkplugMetricsChangedEvent> MetricsUpdated;

    public bool IsConnected => _sparkplugApplication.IsConnected;

    public SparkplugDataAdapter(IOptions<SparkplugDataAdapterOptions> options, IServiceScopeFactory serviceScopeFactory , KnownMetricStore store)
    {
        _serviceScopeFactory = serviceScopeFactory;

        SparkplugDataAdapterOptions parameter = options.Value;

        //var applicationMetrics = store.Metrics;
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
    }

    public async Task StartApplicationAsync()
    {
        await _sparkplugApplication.Start(_sparkplugApplicationOptions);

        _sparkplugApplication.OnDisconnected = OnApplicationDisconnected;
        _sparkplugApplication.OnDeviceDataReceived = OnVersionBDeviceDataReceived;
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

    public void HandleNodeConnectionChanged(SparkplugNodeConnectionChangedEvent e)
    {
        NodeConnectionChanged.Invoke(e);
    }
    
    public void HandleDeviceConnectionChanged(SparkplugDeviceConnectionChangedEvent e)
    {
        DeviceConnectionChanged.Invoke(e);
    }

    public void HandleMetricsUpdated(SparkplugMetricsChangedEvent e)
    {
        MetricsUpdated.Invoke(e);
    }

    public void OnApplicationDisconnected()
    {
        Console.WriteLine("Disconnected !!!");
    }

    public void OnVersionBDeviceDataReceived(Metric metric)
    {
        Console.WriteLine("nhan dc data r ne");
        Console.WriteLine(metric.Name);
        Console.WriteLine(metric.ValueCase.ToString());
    }

    public List<Metric> KnownMetrics()
    {
        return _sparkplugApplication.KnownMetrics;
    }
}
