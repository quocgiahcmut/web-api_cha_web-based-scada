namespace Application.Queries.Devices;

public class GetDeviceByIdQuery : IRequest<Device>
{
    public string DeviceId { get; set; }

    public GetDeviceByIdQuery(string deviceId)
    {
        DeviceId = deviceId;
    }
}
