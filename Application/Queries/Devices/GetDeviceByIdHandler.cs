namespace Application.Queries.Devices;

public class GetDeviceByIdHandler : IRequestHandler<GetDeviceById, Device>
{
    private readonly IDeviceRepository _deviceRepository;

    public GetDeviceByIdHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<Device> Handle(GetDeviceById request, CancellationToken cancellationToken)
    {
        var device = await _deviceRepository.FindById(request.DeviceId);

        return device;
    }
}
