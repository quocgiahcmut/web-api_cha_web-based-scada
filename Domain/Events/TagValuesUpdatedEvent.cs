namespace Domain.Events;

public class TagValuesUpdatedEvent : INotification
{
    public string EonNodeId { get; set; }
    public string DeviceId { get; set; }
    public string TagName { get; set; }
    public object Value { get; set; }

    public TagValuesUpdatedEvent(string eonNodeId, string deviceId, string tagName, object value)
    {
        EonNodeId = eonNodeId;
        DeviceId = deviceId;
        TagName = tagName;
        Value = value;
    }
}
