namespace Application.Queries.Devices;

public class GetAllDevicesQueryHandler : IRequestHandler<GetAllDevicesQuery, IEnumerable<Device>>
{
    private readonly IDeviceRepository _deviceRepository;

    public GetAllDevicesQueryHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<IEnumerable<Device>> Handle(GetAllDevicesQuery request, CancellationToken cancellationToken)
    {
        var devices = await _deviceRepository.GetAllDevice();

        return devices;
    }
}
