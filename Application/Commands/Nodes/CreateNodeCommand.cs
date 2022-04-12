namespace Application.Commands.Nodes;

public class CreateNodeCommand : IRequest<bool>
{
    public string NodeId { get; set; }
    public bool Connected { get; set; }

    public CreateNodeCommand(string nodeId, bool connected)
    {
        NodeId = nodeId;
        Connected = connected;
    }
}
