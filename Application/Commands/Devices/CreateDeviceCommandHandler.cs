namespace Application.Commands.Devices;

public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, bool>
{
    private readonly IDeviceRepository _deviceRepository;

    public CreateDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<bool> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = new Device(request.DeviceId, request.EonNodeId, request.Connected);

        await _deviceRepository.Add(device);

        return await _deviceRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
