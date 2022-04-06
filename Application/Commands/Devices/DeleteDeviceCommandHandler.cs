namespace Application.Commands.Devices;

public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, bool>
{
    private readonly IDeviceRepository _deviceRepository;

    public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<bool> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await _deviceRepository.FindById(request.DeviceId);

        _deviceRepository.Delete(device);

        return await _deviceRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
