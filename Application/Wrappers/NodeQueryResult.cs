namespace Application.Wrappers;

public class NodeQueryResult
{
    public string EonNodeId { get; set; }
    public bool Connected { get; set; }
    public List<DeviceQueryResult> DeviceQueryResults { get; set; }
}
