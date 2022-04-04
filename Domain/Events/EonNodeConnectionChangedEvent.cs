namespace Domain.Events;

public class EonNodeConnectionChangedEvent : INotification
{
    public string EonNodeId { get; set; }
    public bool Connected { get; set; }

    public EonNodeConnectionChangedEvent(string eonNodeId, bool connected)
    {
        EonNodeId = eonNodeId;
        Connected = connected;
    }
}
