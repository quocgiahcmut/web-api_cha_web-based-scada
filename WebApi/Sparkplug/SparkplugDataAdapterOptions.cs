namespace WebApi.Sparkplug;

public class SparkplugDataAdapterOptions
{
    public string BrokerAddress { get; set; }
    public int Port { get; set; }
    public string ClientId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool UseTls { get; set; }
    public string ScadaHostIdentifier { get; set; }
    public double ReconnectInterval { get; set; }
    public bool IsPrimaryApplication { get; set; }
}
