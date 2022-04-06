namespace Application.EventHandlers;

public class DeviceConnectionChangedEventHandler : INotificationHandler<DeviceConnectionChangedEvent>
{
    private readonly IDeviceRepository _repository;

    public DeviceConnectionChangedEventHandler(IDeviceRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeviceConnectionChangedEvent notification, CancellationToken cancellationToken)
    {
        var device = await _repository.FindById(notification.DeviceId);

        device.Connected = notification.Connected;

        _repository.Update(device);

        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
