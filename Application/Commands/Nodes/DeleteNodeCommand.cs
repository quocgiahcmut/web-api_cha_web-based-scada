namespace Application.Commands.Nodes;

public class DeleteNodeCommand : IRequest<bool>
{
    public string EonNodeId { get; set; }

    public DeleteNodeCommand(string eonNodeId)
    {
        EonNodeId = eonNodeId;
    }
}
