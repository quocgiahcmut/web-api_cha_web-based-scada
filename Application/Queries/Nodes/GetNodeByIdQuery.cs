namespace Application.Queries.Nodes;

public class GetNodeByIdQuery : IRequest<EonNode>
{
    public string NodeId { get; set; }

    public GetNodeByIdQuery(string nodeId)
    {
        NodeId = nodeId;
    }
}
