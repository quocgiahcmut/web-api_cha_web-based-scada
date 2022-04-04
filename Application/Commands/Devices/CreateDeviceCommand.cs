namespace Application.Commands.Devices;

public class CreateDeviceCommand : IRequest<bool>
{
    public string Id { get; set; }
    public string EonNodeId { get; set; }
    public bool Connected { get; set; }

    public CreateDeviceCommand(string id, string eonNodeId, bool connected)
    {
        Id = id;
        EonNodeId = eonNodeId;
        Connected = connected;
    }
}
