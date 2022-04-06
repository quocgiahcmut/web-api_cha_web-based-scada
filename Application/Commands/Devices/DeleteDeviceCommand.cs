namespace Application.Commands.Devices;

public class DeleteDeviceCommand : IRequest<bool>
{
    public string DeviceId { get; set; }

    public DeleteDeviceCommand(string deviceId)
    {
        DeviceId = deviceId;
    }
}
