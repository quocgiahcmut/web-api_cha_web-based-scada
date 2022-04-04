namespace Application.Queries;

public class NodeQuery : IRequest<NodeQueryResult>
{
    public string EonNodeId { get; set; }
    public List<DeviceQuery> DeviceQueries { get; set; }
}
