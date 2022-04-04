namespace Domain.Events;

public class DeviceConnectionChangedEvent : INotification
{
    public string EonNodeId { get; set; }
    public string DeviceId { get; set; }
    public bool Connected { get; set; }

    public DeviceConnectionChangedEvent(string eonNodeId, string deviceId, bool connected)
    {
        EonNodeId = eonNodeId;
        DeviceId = deviceId;
        Connected = connected;
    }
}
