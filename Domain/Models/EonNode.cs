namespace Domain.Models;
public class EonNode
{
    public string Id { get; set; }
    public bool Connected { get; set; }
    public List<Device> Devices { get; set; }
}
