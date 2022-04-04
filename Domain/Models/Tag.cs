namespace Domain.Models;

public class Tag
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DeviceId { get; set; }
    public string EonNodeId { get; set; }
    public EDataType DataType { get; set; }
}
