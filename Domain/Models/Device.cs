namespace Domain.Models;

public class Device
{
    public string Id { get; set; }
    public string EonNodeId { get; set; }
    public bool Connected { get; set; }
    public List<Tag> Tags { get; set; }
}
