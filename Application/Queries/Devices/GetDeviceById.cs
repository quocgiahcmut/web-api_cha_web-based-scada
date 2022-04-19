namespace Application.Queries.Devices;

public class GetDeviceById : IRequest<Device>
{
    public string DeviceId { get; set; }

    public GetDeviceById(string deviceId)
    {
        DeviceId = deviceId;
    }
}
