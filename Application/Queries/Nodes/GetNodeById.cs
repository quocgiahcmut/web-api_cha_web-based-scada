namespace Application.Queries.Nodes;

public class GetNodeById : IRequest<EonNode>
{
    public string NodeId { get; set; }

    public GetNodeById(string nodeId)
    {
        NodeId = nodeId;
    }
}
