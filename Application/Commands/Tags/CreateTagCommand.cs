namespace Application.Commands.Tags;

public class CreateTagCommand : IRequest<bool>
{
    public string TagId { get; private set; }
    public string TagName { get; private set; }
    public string DeviceId { get; private set; }
    public string EonNodeId { get; private set; }
    public EDataType DataType { get; private set; }

    public CreateTagCommand(string tagId, string tagName, string deviceId, string eonNodeId, EDataType dataType)
    {
        TagId = tagId;
        TagName = tagName;
        DeviceId = deviceId;
        EonNodeId = eonNodeId;
        DataType = dataType;
    }
}
