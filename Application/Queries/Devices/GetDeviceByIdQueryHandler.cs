namespace Application.Queries.Devices;

public class GetDeviceByIdQueryHandler : IRequestHandler<GetDeviceByIdQuery, Device>
{
    private readonly IDeviceRepository _deviceRepository;

    public GetDeviceByIdQueryHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Device> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
    {
        var device = await _deviceRepository.FindById(request.DeviceId);

        return device;
    }
}
