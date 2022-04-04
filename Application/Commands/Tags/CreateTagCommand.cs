namespace Application.Commands.Tags;

public class CreateTagCommand : IRequest<bool>
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string DeviceId { get; private set; }
    public string EonNodeId { get; private set; }
    public EDataType DataType { get; private set; }

    public CreateTagCommand(string id, string name, string deviceId, string eonNodeId, EDataType dataType)
    {
        Id = id;
        Name = name;
        DeviceId = deviceId;
        EonNodeId = eonNodeId;
        DataType = dataType;
    }
}
