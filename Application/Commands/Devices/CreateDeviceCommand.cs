namespace Application.Commands.Devices;

public class CreateDeviceCommand : IRequest<bool>
{
    public string DeviceId { get; set; }
    public string EonNodeId { get; set; }
    public bool Connected { get; set; }

    public CreateDeviceCommand(string deviceId, string eonNodeId, bool connected)
    {
        DeviceId = deviceId;
        EonNodeId = eonNodeId;
        Connected = connected;
    }
}
