namespace Application.EventHandlers;

public class EonNodeConnectionChangedEventHandler : INotificationHandler<EonNodeConnectionChangedEvent>
{
    private readonly IEonNodeRepository _repository;

    public EonNodeConnectionChangedEventHandler(IEonNodeRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(EonNodeConnectionChangedEvent notification, CancellationToken cancellationToken)
    {
        var eonNode = await _repository.FindById(notification.EonNodeId);

        eonNode.Connected = notification.Connected;
        
        await _repository.Update(eonNode);
    }
}
